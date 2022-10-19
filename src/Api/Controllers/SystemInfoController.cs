using Common;
using Common.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/systeminfo")]
[Produces("application/json")]
[Consumes("application/json")]
public class SystemInfoController : ControllerBase
{
	private readonly AppConfiguration _appConfiguration;

	public SystemInfoController(AppConfiguration appConfiguration)
	{
		_appConfiguration = appConfiguration;
	}

	/// <summary>
	/// Fetches information about the service and system.
	/// </summary>
	/// <returns>SystemInfoGetResponse</returns>
	/// <response code="200">Returns the system information</response>
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public ActionResult<SystemInfoGetResponse> Get()
	{
		return GetData();
	}

	private SystemInfoGetResponse GetData()
	{
		return new SystemInfoGetResponse()
		{
			OperatingSystem = Environment.OSVersion.Platform.ToString(),
			OperatingSystemVersion = Environment.OSVersion.VersionString,

			RunTimeVersion = Environment.Version.ToString(),

			Version = Constants.AppVersion,

			GitHub = "https://github.com/philosowaffle/ambientweather-local-server",
			Documentation = "https://philosowaffle.github.io/ambientweather-local-server/",
			Forums = "https://github.com/philosowaffle/ambientweather-local-server/discussions",
			Donate = "https://www.buymeacoffee.com/philosowaffle",
			Issues = "https://github.com/philosowaffle/ambientweather-local-server/issues",
			Api = $"{_appConfiguration.Api.HostUrl}/swagger"
		};
	}
}
