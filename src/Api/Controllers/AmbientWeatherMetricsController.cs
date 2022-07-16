using Common.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/ambientweather/metrics")]
[ApiController]
[Produces("application/json")]
[Consumes("application/x-www-form-urlencoded")]
public class AmbientWeatherMetricsController : ControllerBase
{
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	public Task PostAsync([FromQuery]AmbientWeatherMetricsPostRequest request)
	{
		return Task.FromResult(Created("/metrics", null));
	}
}
