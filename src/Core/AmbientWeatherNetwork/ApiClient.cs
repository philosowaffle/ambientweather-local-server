using Common.Observe;
using Common;
using Serilog;
using Flurl.Http;
using Core.AmbientWeatherNetwork.Dto;

namespace Core.AmbientWeatherNetwork;

public interface IApiClient
{
	Task<ICollection<UserDevice>> GetLatestFromDevicesAsync(string apiKey, string applicationKey);
}

public class ApiClient : IApiClient
{
	private const string Host = "https://rt.ambientweather.net";

	private static readonly ILogger _logger = LogContext.ForClass<ApiClient>();

	public Task<ICollection<UserDevice>> GetLatestFromDevicesAsync(string apiKey, string applicationKey)
	{
		return $"{Host}/v1/devices"
				.WithHeader("Content-Type", "application/json")
				.SetQueryParams(new 
				{
					applicationKey =  applicationKey,
					apiKey = apiKey
				})
				.StripSensitiveDataFromLogging(apiKey, applicationKey)
				.GetJsonAsync<ICollection<UserDevice>>();
	}
}
