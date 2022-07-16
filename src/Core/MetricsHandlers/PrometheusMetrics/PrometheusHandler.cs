using Common.Contracts;

namespace Core.MetricsHandlers.PrometheusMetrics;

public class PrometheusHandler : IMetricsHandler
{
	public Task ProcessAsync(AmbientWeatherMetricsPostRequest metrics)
	{
		ProcessWindDirection(metrics);

		return Task.CompletedTask;
	}

	public void ProcessWindDirection(AmbientWeatherMetricsPostRequest metrics)
	{
		if (metrics.WindDir.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.WindDirection
				.WithLabels("wind")
				.Set(metrics.WindDir.Value);
		}

		if (metrics.WindGustDir.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.WindDirection
				.WithLabels("gust")
				.Set(metrics.WindGustDir.Value);
		}

		if (metrics.WindDir_Avg2m.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.WindDirection
				.WithLabels("2mAvg")
				.Set(metrics.WindDir_Avg2m.Value);
		}

		if (metrics.WindDir_Avg10m.HasValue)
		{
			AmbientWeatherPrometheusMetrics
				.WindDirection
				.WithLabels("10mAvg")
				.Set(metrics.WindDir.Value);
		}
	}
}
