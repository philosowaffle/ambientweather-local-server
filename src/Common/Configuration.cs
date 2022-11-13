using Microsoft.Extensions.Configuration;
using Serilog;

namespace Common;

public static class ConfigurationSetup
{
	public static void LoadConfigValues(IConfiguration provider, AppConfiguration config)
	{
		provider.GetSection("Api").Bind(config.Api);
		provider.GetSection("AmbientWeather").Bind(config.AmbientWeatherSettings);
		provider.GetSection(nameof(Observability)).Bind(config.Observability);
		provider.GetSection(nameof(Developer)).Bind(config.Developer);
	}

	public static bool IsValid(this AmbientWeatherSettings settings)
	{
		if (!settings.EnrichFromAmbientWeatherNetwork) return true;

		if (string.IsNullOrWhiteSpace(settings.ApplicationKey))
		{
			Log.Error("ApplicationKey is required for enriching from the AmbientWeather Network");
			return false;
		}

		if (string.IsNullOrWhiteSpace(settings.UserApiKey))
		{
			Log.Error("UserApiKey is required for enriching from the AmbientWeather Network");
			return false;
		}

		if (settings.PollingFrequencySeconds <= 0)
		{
			Log.Error("PollingFrequencySeconds must be greater than 0 seconds for enriching from the AmbientWeather Network");
			return false;
		}

		return true;
	}
}

/// <summary>
/// Configuration that must be provided prior to runtime. Typically via config file, command line args, or env variables.
/// </summary>
public class AppConfiguration
{
	public AppConfiguration()
	{
		Api = new ApiSettings();
		AmbientWeatherSettings = new AmbientWeatherSettings();
		Observability = new Observability();
		Developer = new Developer();
	}

	public ApiSettings Api { get; set; }
	public AmbientWeatherSettings AmbientWeatherSettings { get; set; }
	public Observability Observability { get; set; }
	public Developer Developer { get; set; }

	public static string DataDirectory = Path.Join(Environment.CurrentDirectory, "data");
}

public class ApiSettings
{
	public ApiSettings()
	{
		HostUrl = "http://*:8080";
	}

	public string HostUrl { get; set; }
}

public class AmbientWeatherSettings
{
	public bool EnrichFromAmbientWeatherNetwork { get; set; }
	public string? UserApiKey { get; set; }
	public string? ApplicationKey { get; set; }
	public ushort PollingFrequencySeconds { get; set; } = 60;
}

public class Observability
{
	public Observability()
	{
		Metrics = new Metrics();
		Traces = new Traces();
	}

	public Metrics Metrics { get; set; }
	public Traces Traces { get; set; }
}

public class Traces
{
	public Traces()
	{
		AgentHost = "http://localhost";
	}

	public bool Enabled { get; set; }
	public string AgentHost { get; set; }
	public ushort? AgentPort { get; set; }
}

public class Metrics
{
	public bool Enabled { get; set; }
	public bool EnableDotNetRuntimeDebugMetrics { get; set; }
}

public class Developer
{
}
