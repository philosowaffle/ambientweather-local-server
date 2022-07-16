using Prometheus;
using PromMetrics = Prometheus.Metrics;
using Common.Observe;
using Flurl.Http;
using Serilog;

namespace Common;

public static class FlurlConfiguration
{
	public static readonly Histogram HttpRequestHistogram = PromMetrics.CreateHistogram("p2g_http_duration_seconds", "The histogram of http requests.", new HistogramConfiguration
	{
		LabelNames = new[]
		{
				Label.HttpMethod,
				Label.HttpHost,
				Label.HttpRequestPath,
				Label.HttpRequestQuery,
				Label.HttpStatusCode,
				Label.HttpMessage
			}
	});

	public static void Configure(Observability config, int defaultTimeoutSeconds = 10)
	{
		Func<FlurlCall, Task> beforeCallAsync = (FlurlCall call) =>
		{
			try
			{
				Log.Verbose("HTTP Request: {@HttpMethod} - {@Uri} - {@Headers} - {@Content}", call.HttpRequestMessage?.Method?.ToString() ?? "unknown", call.HttpRequestMessage?.RequestUri?.ToString() ?? "unknown", call.HttpRequestMessage?.Headers?.ToString() ?? "unknown", call.HttpRequestMessage?.Content?.ToString() ?? "unknown");
			}
			catch { Console.WriteLine("Error in Flurl.beforeCallAsync"); }

			return Task.CompletedTask;
		};

		Func<FlurlCall, Task> afterCallAsync = async (FlurlCall call) =>
		{
			try
			{
				var responseContent = "unknown";
				if (call.HttpResponseMessage?.Content is not null)
					responseContent = await call.HttpResponseMessage.Content.ReadAsStringAsync();
				Log.Verbose("HTTP Response: {@HttpStatusCode} - {@HttpMethod} - {@Uri} - {@Headers} - {@Content}", call.HttpResponseMessage?.StatusCode.ToString() ?? string.Empty, call.HttpRequestMessage?.Method?.ToString() ?? "unknown", call.HttpRequestMessage?.RequestUri?.ToString() ?? "unknown", call.HttpResponseMessage?.Headers?.ToString() ?? "unknown", responseContent);

				if (config.Metrics.Enabled)
				{
					HttpRequestHistogram
					.WithLabels(
						call.HttpRequestMessage?.Method.ToString() ?? "unknown",
						call.HttpRequestMessage?.RequestUri?.Host ?? "unknown",
						call.HttpRequestMessage?.RequestUri?.AbsolutePath ?? "unknown",
						call.HttpRequestMessage?.RequestUri?.Query ?? "unknown",
						((int?)call.HttpResponseMessage?.StatusCode).ToString() ?? "unknown",
						call.HttpResponseMessage?.ReasonPhrase ?? "unknown"
					).Observe(call.Duration.GetValueOrDefault().TotalSeconds);
				}
			}
			catch { Console.WriteLine("Error in Flurl.afterCallAsync"); }
		};

		Func<FlurlCall, Task> onErrorAsync = async (FlurlCall call) =>
		{
			try
			{
				var response = string.Empty;
				if (call.HttpResponseMessage is object)
					response = await call.HttpResponseMessage?.Content?.ReadAsStringAsync();
				Log.Error("Http Call Failed. {@HttpStatusCode} {@Content}", call.HttpResponseMessage?.StatusCode, response);
			}
			catch { Console.WriteLine("Error in Flurl.onErrorAsync"); }
		};

		FlurlHttp.Configure(settings =>
		{
			settings.Timeout = new TimeSpan(0, 0, defaultTimeoutSeconds);
			settings.BeforeCallAsync = beforeCallAsync;
			settings.AfterCallAsync = afterCallAsync;
			settings.OnErrorAsync = onErrorAsync;
			settings.Redirects.ForwardHeaders = true;
		});
	}
}
