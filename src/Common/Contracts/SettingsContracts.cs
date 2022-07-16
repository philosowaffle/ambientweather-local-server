namespace Common.Contracts;

public class SettingsGetResponse
{
	public AppSettingsGetResponse AppSettings { get; set; }

	public SettingsGetResponse() 
	{
		AppSettings = new AppSettingsGetResponse();
	}

	public SettingsGetResponse(AppSettingsGetResponse appSettings)
	{
		AppSettings = appSettings;
	}
}

public class AppSettingsGetResponse
{
}