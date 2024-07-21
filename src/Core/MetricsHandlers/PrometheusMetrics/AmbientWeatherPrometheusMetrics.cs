using Common;
using Common.Contracts;
using Prometheus;

namespace Core.MetricsHandlers.PrometheusMetrics;

public static class AmbientWeatherPrometheusMetrics
{
	public static readonly Gauge LowBattery = Prometheus.Metrics.CreateGauge($"{Statics.MetricPrefix}_lowbattery_bool", "Gauge of Low Battery State", new GaugeConfiguration()
	{
		LabelNames = new[] { "type", "macAddress", "stationType", "source" }
	});

	public static readonly Gauge Humidity = Prometheus.Metrics.CreateGauge($"{Statics.MetricPrefix}_humidity_percent", "Gauge of Humidity Percentage", new GaugeConfiguration()
	{
		LabelNames = new[] { "type", "macAddress", "stationType", "source" }
	});

	public static readonly Gauge Rain = Prometheus.Metrics.CreateGauge($"{Statics.MetricPrefix}_rain_in", "Gauge of Rain in Inches", new GaugeConfiguration()
	{
		LabelNames = new[] { "type", "macAddress", "stationType", "source" }
	});

	public static readonly Gauge SolarRadiation = Prometheus.Metrics.CreateGauge($"{Statics.MetricPrefix}_solarradiation_wm2", "Gauge of Solar Radiation in w/m^2", new GaugeConfiguration()
	{
		LabelNames = new[] { "type", "macAddress", "stationType", "source" }
	});

	public static readonly Gauge Temperature = Prometheus.Metrics.CreateGauge($"{Statics.MetricPrefix}_temperature_f", "Gauge of Temperature in Fahrenheit", new GaugeConfiguration()
	{
		LabelNames = new[] { "type", "macAddress", "stationType", "source" }
	});

	public static readonly Gauge UVIndex = Prometheus.Metrics.CreateGauge($"{Statics.MetricPrefix}_uv_index", "Gauge of UV Index", new GaugeConfiguration()
	{
		LabelNames = new[] { "type", "macAddress", "stationType", "source" }
	});

	public static readonly Gauge WindDirection = Prometheus.Metrics.CreateGauge($"{Statics.MetricPrefix}_winddirection_deg", "Gauge of WindDirection 0-360deg.", new GaugeConfiguration()
	{
		LabelNames = new[] { "type", "macAddress", "stationType", "source" }
	});

	public static readonly Gauge WindSpeed = Prometheus.Metrics.CreateGauge($"{Statics.MetricPrefix}_windspeed_mph", "Gauge of WindSpeed in MPH", new GaugeConfiguration()
	{
		LabelNames = new[] { "type", "macAddress", "stationType", "source" }
	});

	public static readonly Gauge FeelsLike = Prometheus.Metrics.CreateGauge($"{Statics.MetricPrefix}_feelslike_f", "Gauge of Feels Like Temperature in Fahrenheit", new GaugeConfiguration()
	{
		LabelNames = new[] { "type", "macAddress", "stationType", "source" }
	});

	public static readonly Gauge DewPoint = Prometheus.Metrics.CreateGauge($"{Statics.MetricPrefix}_dewpoint_f", "Gauge of Dew Point Temperature in Fahrenheit", new GaugeConfiguration()
	{
		LabelNames = new[] { "type", "macAddress", "stationType", "source" }
	});

	public static readonly Gauge BaromRelIn = Prometheus.Metrics.CreateGauge($"{Statics.MetricPrefix}_baromrelin", "Gauge of Relative Barometric Pressure in in-Hg", new GaugeConfiguration()
	{
		LabelNames = new[] { "type", "macAddress", "stationType", "source" }
	});

	public static readonly Gauge BaromAbsIn = Prometheus.Metrics.CreateGauge($"{Statics.MetricPrefix}_baromabsin", "Gauge of Absolute Barometric Pressure in in-Hg", new GaugeConfiguration()
	{
		LabelNames = new[] { "type", "macAddress", "stationType", "source" }
	});

	public static readonly Gauge SoilHum = Prometheus.Metrics.CreateGauge($"{Statics.MetricPrefix}_soilhum", "Gauge of Soil Moisture in %", new GaugeConfiguration()
	{
		LabelNames = new[] { "type", "macAddress", "stationType", "source" }
	});
	
	public static readonly Gauge DateUtc = Prometheus.Metrics.CreateGauge($"{Statics.MetricPrefix}_dateutc", "Gauge of Date and Time UTC", new GaugeConfiguration()
	{
		LabelNames = new[] { "type", "macAddress", "stationType", "source" }
	});

	public static TChild WithLabels<TChild>(this Collector<TChild> collector, string type, IAmbientWeatherMetrics metrics)
		where TChild : Prometheus.ChildBase
	{
		return collector.WithLabels(type, metrics.Mac ?? metrics.PassKey ?? "none", metrics.StationType ?? "none", Enum.GetName(metrics.Source)?.ToLower() ?? "Unknown");
	}
}
