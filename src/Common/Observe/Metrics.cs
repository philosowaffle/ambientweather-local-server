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
		PromMetrics.CreateGauge($"{Statics.MetricPrefix}_build_info", "Build info for the running instance.", new GaugeConfiguration()
		{
			LabelNames = new[] { Label.Version, Label.Os, Label.OsVersion, Label.DotNetRuntime, Label.RunningInDocker }
		}).WithLabels(Constants.AppVersion, SystemInformation.OS, SystemInformation.OSVersion, SystemInformation.RunTimeVersion, SystemInformation.RunningInDocker.ToString())
.Set(1);
	}

	public static IDisposable? EnableCollector(Common.Metrics config)
	{
		if (!config.Enabled) return null;

		return DotNetRuntimeStatsBuilder
			.Customize()
			.WithContentionStats()
			.WithJitStats()
			.WithThreadPoolStats()
			.WithGcStats()
			.WithExceptionStats(CaptureLevel.Verbose)
			.WithDebuggingMetrics(config.EnableDotNetRuntimeDebugMetrics)
			.WithErrorHandler(ex => Log.Error(ex, "Unexpected exception occurred in prometheus-net.DotNetRuntime"))
			.StartCollecting();
	}
}

public static class AppMetrics
{
	public static readonly Gauge UpdateAvailable = PromMetrics.CreateGauge($"{Statics.MetricPrefix}_update_available", "Indicates a newer version is availabe.", new GaugeConfiguration()
	{
		LabelNames = new[] { Label.Version, Label.LatestVersion }
	});

	public static void SyncUpdateAvailableMetric(bool isUpdateAvailable, string? latestVersion)
	{
		if (isUpdateAvailable)
		{
			UpdateAvailable
				.WithLabels(Constants.AppVersion, latestVersion ?? string.Empty)
				.Set(1);
		}
		else
		{
			UpdateAvailable
				.WithLabels(Constants.AppVersion, Constants.AppVersion)
				.Set(0);
		}
	}
}
