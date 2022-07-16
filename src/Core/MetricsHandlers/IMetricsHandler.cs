using Common.Contracts;

namespace Core.MetricsHandlers;

public interface IMetricsHandler
{
	Task ProcessAsync(AmbientWeatherMetricsPostRequest metrics);
}
