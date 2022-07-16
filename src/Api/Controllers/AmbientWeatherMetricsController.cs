using Common.Contracts;
using Core.MetricsHandlers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[ApiController]
[Route("api/ambientweather/metrics")]
[Produces("application/json")]
[Consumes("application/x-www-form-urlencoded")]
public class AmbientWeatherMetricsController : ControllerBase
{
	private readonly IEnumerable<IMetricsHandler> _metricsHandlers;
	public AmbientWeatherMetricsController(ICollection<IMetricsHandler> metricsHandlers)
	{
		_metricsHandlers = metricsHandlers;
	}

	/// <summary>
	/// Accepts Metrics from an AmbientWeather station and processes them.
	/// </summary>
	[HttpGet]
	public Task GetAsync([FromQuery] AmbientWeatherMetricsPostRequest request)
	{
		var tasks = new List<Task>(_metricsHandlers.Count());
		foreach (var handler in _metricsHandlers)
			tasks.Add(handler.ProcessAsync(request));

		return Task.WhenAll(tasks);
	}
}
