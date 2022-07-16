using Common.Observe;
using Prometheus;

namespace Core.MetricsHandlers.PrometheusMetrics;

public static class AmbientWeatherPrometheusMetrics
{
	public static readonly Gauge WindDirection = Prometheus.Metrics.CreateGauge($"{Label.LabelPrefix}_winddirection_deg", "Gauge of WindDirection 0-360deg.", new GaugeConfiguration()
	{
		LabelNames = new[] { "type" }
	});
}
