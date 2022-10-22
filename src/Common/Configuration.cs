using Microsoft.Extensions.Configuration;

namespace Common;

public static class ConfigurationSetup
{
	public static void LoadConfigValues(IConfiguration provider, AppConfiguration config)
	{
		provider.GetSection("Api").Bind(config.Api);
		provider.GetSection(nameof(Observability)).Bind(config.Observability);
		provider.GetSection(nameof(Developer)).Bind(config.Developer);
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
		Observability = new Observability();
		Developer = new Developer();
	}

	public ApiSettings Api { get; set; }
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
	public bool Enabled { get; set; }
	public string AgentHost { get; set; }
	public int? AgentPort { get; set; }
}

public class Metrics
{
	public bool Enabled { get; set; }
}

public class Developer
{
}
