using Common.Contracts;
using Core.MetricsHandlers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/ambientweather/metrics")]
[ApiController]
[Produces("application/json")]
[Consumes("application/x-www-form-urlencoded")]
public class AmbientWeatherMetricsController : ControllerBase
{
	private readonly ICollection<IMetricsHandler> _metricsHandlers;
	public AmbientWeatherMetricsController(ICollection<IMetricsHandler> metricsHandlers)
	{
		_metricsHandlers = metricsHandlers;
	}

	/// <summary>
	/// Accepts Metrics from an AmbientWeather station and processes them.
	/// </summary>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public Task PostAsync([FromQuery]AmbientWeatherMetricsPostRequest request)
	{
		var tasks = new List<Task>(_metricsHandlers.Count);
		foreach (var handler in _metricsHandlers)
			tasks.Add(handler.ProcessAsync(request));

		return Task.WhenAll(tasks);
	}

	[HttpGet]
	public Task GetAsync([FromQuery] AmbientWeatherMetricsPostRequest request)
	{
		var tasks = new List<Task>(_metricsHandlers.Count);
		foreach (var handler in _metricsHandlers)
			tasks.Add(handler.ProcessAsync(request));

		return Task.WhenAll(tasks);
	}
}
