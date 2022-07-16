using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using System.Diagnostics;

namespace Common.Observe;

public static class Tracing
{
	public static ActivitySource Source;

	public static void EnableTracing(IServiceCollection services, Traces config)
	{
		if (config.Enabled)
		{
			services.AddOpenTelemetryTracing(
				(builder) => builder
					.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(Label.LabelPrefix))
					.AddSource(Label.LabelPrefix)
					.SetSampler(new AlwaysOnSampler())
					.SetErrorStatusOnException()
					.AddAspNetCoreInstrumentation(c =>
					{
						c.RecordException = true;
						c.Enrich = AspNetCoreEnricher;
					})
					.AddHttpClientInstrumentation(h =>
					{
						h.RecordException = true;
						h.Enrich = HttpEnricher;
					})
					.AddJaegerExporter(o =>
					{
						o.AgentHost = config.AgentHost;
						o.AgentPort = config.AgentPort.GetValueOrDefault();
					})
			);

			Log.Information("Tracing started and exporting to: http://{@Host}:{@Port}", config.AgentHost, config.AgentPort);
		}
	}

	public static Activity Trace(string name)
	{
		var activity = Activity.Current?.Source.StartActivity(name)
			??
			new ActivitySource(Label.LabelPrefix)?.StartActivity(name);

		activity?
			.SetTag("SpanId", activity.SpanId)
			.SetTag("TraceId", activity.TraceId);

		return activity;
	}

	public static Activity WithTag(this Activity activity, string key, string value)
	{
		return activity?.SetTag(key, value);
	}

	public static void ValidateConfig(Observability config)
	{
		if (!config.Traces.Enabled)
			return;

		if (string.IsNullOrEmpty(config.Traces.AgentHost))
		{
			Log.Error("Agent Host must be set: {@ConfigSection}.{@ConfigProperty}.", nameof(config), nameof(config.Traces.AgentHost));
			throw new ArgumentException("Agent Host must be set.", nameof(config.Traces.AgentHost));
		}

		if (config.Traces.AgentPort is null || config.Traces.AgentPort <= 0)
		{
			Log.Error("Agent Port must be set: {@ConfigSection}.{@ConfigProperty}.", nameof(config), nameof(config.Traces.AgentPort));
			throw new ArgumentException("Agent Port must be a valid port.", nameof(config.Traces.AgentPort));
		}
	}

	public static void HttpEnricher(Activity activity, string name, object rawEventObject)
	{
		if (name.Equals("OnStartActivity"))
		{
			if (rawEventObject is HttpRequestMessage request)
			{
				activity.DisplayName = $"{request.Method} {request.RequestUri.AbsolutePath}";
				activity.SetTag("http.path", request.RequestUri.AbsolutePath);
				activity.SetTag("http.query", request.RequestUri.Query);
				activity.SetTag("http.body", request.Content?.ReadAsStringAsync().GetAwaiter().GetResult() ?? "no_content");
			}
		}
		else if (name.Equals("OnStopActivity"))
		{
			if (rawEventObject is HttpResponseMessage response)
			{
				activity.SetTag("http.response.body", response.Content?.ReadAsStringAsync().GetAwaiter().GetResult() ?? "no_content");
			}
		}
		else if (name.Equals("OnException"))
		{
			if (rawEventObject is Exception exception)
			{
				activity.SetTag("error.stackTrace", exception.StackTrace);
			}
		}
	}

	public static void AspNetCoreEnricher(Activity activity, string name, object rawEventObject)
	{
		if (name.Equals("OnStartActivity")
			&& rawEventObject is HttpRequest httpRequest)
		{
			if (httpRequest.Headers.TryGetValue("TraceId", out var incomingTraceParent))
				activity.SetParentId(incomingTraceParent);

			if (httpRequest.Headers.TryGetValue("uber-trace-id", out incomingTraceParent))
				activity.SetParentId(incomingTraceParent);

			activity.SetTag("http.path", httpRequest.Path);
			activity.SetTag("http.query", httpRequest.QueryString);
		}
	}
}
