using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Contracts;

namespace Core.MetricsHandlers.PrometheusMetrics;

public class PrometheusHandler : IMetricsHandler
{
	public Task ProcessAsync(AmbientWeatherMetricsPostRequest metrics)
	{
		throw new NotImplementedException();
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
