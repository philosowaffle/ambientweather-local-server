using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using System.Diagnostics;

namespace Common.Observe;

public static class Tracing
{
	public static ActivitySource? Source;

	public static void EnableApiTracing(IServiceCollection services, Traces config)
	{
		if (!config.Enabled)
			return;

		services.AddOpenTelemetryTracing(
			(builder) =>
			{
				builder
				.ConfigureDefaultBuilder(config)
				.AddAspNetCoreInstrumentation(c =>
				{
					c.RecordException = true;
					c.Enrich = AspNetCoreEnricher;
				});
			});

		Log.Information("Tracing started and exporting to: http://{@Host}:{@Port}", config.AgentHost, config.AgentPort);

	}

	public static void EnableWebUITracing(IServiceCollection services, Traces config)
	{
		if (!config.Enabled)
			return;

		services.AddOpenTelemetryTracing(
			(builder) =>
			{
				builder.ConfigureDefaultBuilder(config);
			});

		Log.Information("Tracing started and exporting to: http://{@Host}:{@Port}", config.AgentHost, config.AgentPort);
	}

	private static TracerProviderBuilder ConfigureDefaultBuilder(this TracerProviderBuilder builder, Traces config)
	{
		return builder
				.AddSource(Statics.TracingService)
				.SetResourceBuilder(
					ResourceBuilder
					.CreateDefault()
					.AddService(serviceName: Statics.TracingService, serviceVersion: Constants.AppVersion)
					.AddAttributes(new List<KeyValuePair<string, object>>()
					{
							new KeyValuePair<string, object>("host.machineName", Environment.MachineName),
							new KeyValuePair<string, object>("host.os", Environment.OSVersion.VersionString),
							new KeyValuePair<string, object>("dotnet.version", Environment.Version.ToString()),
					})
				)
				.SetSampler(new AlwaysOnSampler())
				.SetErrorStatusOnException()
				.AddHttpClientInstrumentation(h =>
				{
					h.RecordException = true;
					h.Enrich = HttpEnricher;
				})
				.AddJaegerExporter(o =>
				{
					o.AgentHost = config.AgentHost;
					o.AgentPort = config.AgentPort.GetValueOrDefault();
					o.Protocol = OpenTelemetry.Exporter.JaegerExportProtocol.UdpCompactThrift;
				});
	}

	public static Activity? Trace(string name, string category = "app", ActivityKind kind = ActivityKind.Server)
	{
		var activity = Source?.StartActivity(name, kind);

		activity?
		.SetTag("category", category)
			.SetTag("SpanId", activity.SpanId)
			.SetTag("TraceId", activity.TraceId);

		return activity;
	}

	public static Activity? ClientTrace(string name, string category = "app", ActivityKind kind = ActivityKind.Client)
	{
		if (Activity.Current is null || Activity.Current.Kind != ActivityKind.Client)
		{
			Activity.Current?.Dispose();
			Activity.Current = null;
			Activity.Current = Source?.CreateActivity(name, kind);
		}

		var activity = Source?.StartActivity(name, kind);

		activity?
		.SetTag("category", category)
			.SetTag("SpanId", activity.SpanId)
			.SetTag("TraceId", activity.TraceId);

		return activity;
	}

	public static Activity? WithTag(this Activity? activity, string key, string value)
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
				activity.DisplayName = $"{request.Method} {request?.RequestUri?.AbsolutePath}";
				activity.SetTag("http.request.path", request?.RequestUri?.AbsolutePath);
				activity.SetTag("http.request.query", request?.RequestUri?.Query);
				activity.SetTag("http.request.body", request?.Content?.ReadAsStringAsync().GetAwaiter().GetResult() ?? "no_content");
			}
		}
		else if (name.Equals("OnStopActivity"))
		{
			if (rawEventObject is HttpResponseMessage response)
			{
				var content = response.Content?.ReadAsStringAsync().GetAwaiter().GetResult() ?? "no_content";
				activity.SetTag("http.response.body", content);
			}
		}
		else if (name.Equals("OnException"))
		{
			if (rawEventObject is Exception exception)
			{
				activity.SetTag("stackTrace", exception.StackTrace);
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
