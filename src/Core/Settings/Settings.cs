using Common.Contracts;

namespace Core.Settings;

public record struct Settings
{
	public AppSettings AppSettings { get; set; }

	public Settings()
	{
		AppSettings = new AppSettings();
	}

	public Settings(AppSettings appSettings)
	{
		AppSettings = appSettings;
	}

	public Settings(SettingsGetResponse settingsGetResponse)
	{
		AppSettings = new AppSettings(settingsGetResponse.AppSettings);
	}
}

public record struct AppSettings
{
	public AppSettings() { }

	public AppSettings(AppSettingsGetResponse settings)
	{
	}
}
