using Common.Observe;
using Prometheus;

namespace Core.MetricsHandlers.PrometheusMetrics;

public static class AmbientWeatherPrometheusMetrics
{
	public static readonly Gauge LowBattery = Prometheus.Metrics.CreateGauge($"{Label.LabelPrefix}_lowbattery_bool", "Gauge of Low Battery State", new GaugeConfiguration()
	{
		LabelNames = new[] { "type" }
	});

	public static readonly Gauge Humidity = Prometheus.Metrics.CreateGauge($"{Label.LabelPrefix}_humiditiy_percent", "Gauge of Humidity Percentage", new GaugeConfiguration()
	{
		LabelNames = new[] { "type" }
	});

	public static readonly Gauge Rain = Prometheus.Metrics.CreateGauge($"{Label.LabelPrefix}_rain_in", "Gauge of Rain in Inches", new GaugeConfiguration()
	{
		LabelNames = new[] { "type" }
	});

	public static readonly Gauge SolarRadiation = Prometheus.Metrics.CreateGauge($"{Label.LabelPrefix}_solarradiation_wm2", "Gauge of Solar Radiation in w/m^2", new GaugeConfiguration()
	{
		LabelNames = new[] { "type" }
	});

	public static readonly Gauge Temperature = Prometheus.Metrics.CreateGauge($"{Label.LabelPrefix}_temperature_f", "Gauge of Temperature in Fahrenheit", new GaugeConfiguration()
	{
		LabelNames = new[] { "type" }
	});

	public static readonly Gauge UVIndex = Prometheus.Metrics.CreateGauge($"{Label.LabelPrefix}_uv_index", "Gauge of UV Index", new GaugeConfiguration()
	{
		LabelNames = new[] { "type" }
	});

	public static readonly Gauge WindDirection = Prometheus.Metrics.CreateGauge($"{Label.LabelPrefix}_winddirection_deg", "Gauge of WindDirection 0-360deg.", new GaugeConfiguration()
	{
		LabelNames = new[] { "type" }
	});

	public static readonly Gauge WindSpeed = Prometheus.Metrics.CreateGauge($"{Label.LabelPrefix}_windspeed_mph", "Gauge of WindSpeed in MPH", new GaugeConfiguration()
	{
		LabelNames = new[] { "type" }
	});
}
