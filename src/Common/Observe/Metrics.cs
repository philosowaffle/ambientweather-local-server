using Prometheus;
using Prometheus.DotNetRuntime;
using Serilog;
using PromMetrics = Prometheus.Metrics;

namespace Common.Observe;

public static class Metrics
{
	public static void ValidateConfig(Observability config)
	{
		if (!config.Metrics.Enabled) return;
	}

	public static IDisposable EnableCollector(Common.Metrics config)
	{
		if (config.Enabled)
			return DotNetRuntimeStatsBuilder
				.Customize()
				.WithContentionStats()
				.WithJitStats()
				.WithThreadPoolStats()
				.WithGcStats()
				.WithExceptionStats()
				//.WithDebuggingMetrics(true)
				.WithErrorHandler(ex => Log.Error(ex, "Unexpected exception occurred in prometheus-net.DotNetRuntime"))
				.StartCollecting();

		return null;
	}
}

public static class DbMetrics
{
	public static readonly Histogram DbActionDuration = PromMetrics.CreateHistogram(Label.DbDuration, "Counter of db actions.", new HistogramConfiguration()
	{
		LabelNames = new[] { Label.DbMethod, Label.DbQuery }
	});
}
