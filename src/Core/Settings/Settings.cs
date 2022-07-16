using Common.Contracts;

namespace Core.Settings;

public record Settings
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

public record AppSettings
{
	public AppSettings() { }

	public AppSettings(AppSettingsGetResponse settings)
	{
	}
}
