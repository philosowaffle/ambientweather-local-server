using Common.Contracts;
using Flurl.Http;

namespace WebUI;

public interface IApiClient
{
	Task<SystemInfoGetResponse> SystemInfoGetAsync();
	Task<SettingsGetResponse> SettingsGetAsync();
	Task<SettingsGetResponse> SettingsPostAsync(SettingsGetResponse request);
}

public class ApiClient : IApiClient
{
	private string _apiUrl;

	public ApiClient(string apiUrl)
	{
		_apiUrl = apiUrl;
	}

	public Task<SettingsGetResponse> SettingsGetAsync()
	{
		return $"{_apiUrl}/api/settings"
				.GetJsonAsync<SettingsGetResponse>();
	}

	public async Task<SettingsGetResponse> SettingsPostAsync(SettingsGetResponse request)
	{
		return await $"{_apiUrl}/api/settings"
			.PostJsonAsync(request)
			.ReceiveJson<SettingsGetResponse>();
	}

	public Task<SystemInfoGetResponse> SystemInfoGetAsync()
	{
		return $"{_apiUrl}/api/systemInfo"
				.GetJsonAsync<SystemInfoGetResponse>();
	}
}
