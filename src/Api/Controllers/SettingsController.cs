using System.Net;
using Common.Contracts;
using Core.Settings;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/settings")]
[Produces("application/json")]
[Consumes("application/json")]
public class SettingsController : ControllerBase
{
	private readonly ISettingsService _service;

	public SettingsController(ISettingsService service)
	{
		_service = service;
	}

	/// <summary>
	/// Gets the current settings.
	/// </summary>
	/// <response code="200">Returns the settings</response>
	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<ActionResult<SettingsGetResponse>> GetAsync()
	{
		var settings = await _service.GetAsync();
		var response = Map(settings);

		return Ok(response);
	}

	/// <summary>
	/// Creates or updates the Settings.
	/// </summary>
	/// <response code="201">Returns the created link</response>
	/// <response code="400">Invalid link</response>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]
	public async Task<ActionResult<SettingsGetResponse>> PostAsync([FromBody] SettingsGetResponse request)
	{
		if (request is null)
		{
			var error = new ErrorResponse();
			error.Errors.Add(new Error("Request body must not be null."));
			return BadRequest(error);
		}

		var updatedSettings = new Settings(request);
		var updated = await _service.UpsertAsync(updatedSettings);

		if (!updated)
			return Problem("Failed to update Settings.", statusCode: (int)HttpStatusCode.InternalServerError);

		var settings = await _service.GetAsync();
		var response = Map(settings);

		return Created("/settings", response);
	}

	/// <summary>
	/// Creates or updates the App Settings.
	/// </summary>
	[HttpPost]
	[Route("/api/settings/app")]
	[ProducesResponseType(StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError)]
	public async Task<ActionResult<AppSettingsGetResponse>> AppPostAsync([FromBody] AppSettingsGetResponse request)
	{
		if (request is null)
		{
			var error = new ErrorResponse();
			error.Errors.Add(new Error("Request body must not be null."));
			return BadRequest(error);
		}

		var updatedSettings = await _service.GetAsync();
		updatedSettings.AppSettings = new AppSettings(request);

		var updated = await _service.UpsertAsync(updatedSettings);

		if (!updated)
			return Problem("Failed to update App Settings.", statusCode: (int)HttpStatusCode.InternalServerError);

		var settings = await _service.GetAsync();
		var response = Map(settings);

		return Created("/settings/app", response);
	}

	private static SettingsGetResponse Map(Settings settings)
	{
		return new SettingsGetResponse()
		{
			AppSettings = new AppSettingsGetResponse()
			{
			}
		};
	}
}