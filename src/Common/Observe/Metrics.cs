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

	public static void CreateAppInfo()
	{
		PromMetrics.CreateGauge("p2g_build_info", "Build info for the running instance.", new GaugeConfiguration()
		{
			LabelNames = new[] { Label.Version, Label.Os, Label.OsVersion, Label.DotNetRuntime, Label.RunningInDocker }
		}).WithLabels(Constants.AppVersion, SystemInformation.OS, SystemInformation.OSVersion, SystemInformation.RunTimeVersion, SystemInformation.RunningInDocker.ToString())
.Set(1);
	}

	public static IDisposable? EnableCollector(Common.Metrics config)
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
