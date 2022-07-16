using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Contracts;

namespace Core.MetricsHandlers.Prometheus;

public class PrometheusHandler : IMetricsHandler
{
	public Task ProcessAsync(AmbientWeatherMetricsPostRequest metrics)
	{
		throw new NotImplementedException();
	}
}
