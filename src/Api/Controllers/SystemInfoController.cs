using Common;
using Common.Contracts;
using Common.Observe;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/systeminfo")]
[ApiController]
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
	[Produces("application/json")]
	public SystemInfoGetResponse Get()
	{
		using var tracing = Tracing.Trace($"{nameof(SystemInfoController)}.{nameof(Get)}");

		return GetData();
	}

	private SystemInfoGetResponse GetData()
	{
		using var tracing = Tracing.Trace($"{nameof(SystemInfoController)}.{nameof(GetData)}");

		return new SystemInfoGetResponse()
		{
			OperatingSystem = Environment.OSVersion.Platform.ToString(),
			OperatingSystemVersion = Environment.OSVersion.VersionString,

			RunTimeVersion = Environment.Version.ToString(),

			Version = Constants.AppVersion,

			GitHub = "https://github.com/philosowaffle/blazor-template",
			Documentation = "https://philosowaffle.github.io/blazor-template/",
			Forums = "https://github.com/philosowaffle/blazor-template/discussions",
			Donate = "https://www.buymeacoffee.com/philosowaffle",
			Issues = "https://github.com/philosowaffle/blazor-template/issues",
			Api = $"{_appConfiguration.Api.HostUrl}/swagger"
		};
	}
}
