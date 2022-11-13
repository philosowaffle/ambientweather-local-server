using Common;
using FluentAssertions;
using NUnit.Framework;

namespace UnitTests.Common;
public class ConfigurationTests
{
	[Test]
	public void DefaultConfigInit_App_ShouldHaveDefaulValues()
	{
		var config = new AppConfiguration();

		config.AmbientWeatherSettings.Should().NotBeNull();
		config.Api.Should().NotBeNull();
		config.Developer.Should().NotBeNull();
		config.Observability.Should().NotBeNull();
	}

	[Test]
	public void DefaultConfigInit_ApiSettings_ShouldHaveDefaulValues()
	{
		var config = new ApiSettings();

		config.HostUrl.Should().Be("http://*:8080");
	}

	[Test]
	public void DefaultConfigInit_AmbientWeatherSettings_ShouldHaveDefaulValues()
	{
		var config = new AmbientWeatherSettings();

		config.EnrichFromAmbientWeatherNetwork.Should().BeFalse();
		config.UserApiKey.Should().BeNull();
		config.ApplicationKey.Should().BeNull();
		config.PollingFrequencySeconds.Should().Be(60);
	}

	[Test]
	public void DefaultConfigInit_Observability_Metrics_ShouldHaveDefaulValues()
	{
		var config = new AppConfiguration();

		config.Observability.Should().NotBeNull();
		config.Observability.Metrics.Should().NotBeNull();
		config.Observability.Metrics.Enabled.Should().BeFalse();
	}

	[Test]
	public void DefaultConfigInit_Observability_Traces_ShouldHaveDefaulValues()
	{
		var config = new AppConfiguration();

		config.Observability.Should().NotBeNull();
		config.Observability.Traces.Should().NotBeNull();
		config.Observability.Traces.AgentHost.Should().Be("http://localhost");
		config.Observability.Traces.AgentPort.Should().BeNull();
	}

	[Test]
	public void DefaultConfigInit_Developer_ShouldHaveDefaulValues()
	{
		var config = new AppConfiguration();

		config.Developer.Should().NotBeNull();
	}

	[TestCase(false, (ushort)0, null, null, ExpectedResult = true)]
	[TestCase(true, (ushort)0, null, null, ExpectedResult = false)]
	[TestCase(true, (ushort)10, "key", "key", ExpectedResult = true)]

	[TestCase(true, (ushort)10, null, "key", ExpectedResult = false)]
	[TestCase(true, (ushort)10, "", "key", ExpectedResult = false)]
	[TestCase(true, (ushort)10, " ", "key", ExpectedResult = false)]

	[TestCase(true, (ushort)10, "key", null, ExpectedResult = false)]
	[TestCase(true, (ushort)10, "key", "", ExpectedResult = false)]
	[TestCase(true, (ushort)10, "key", " ", ExpectedResult = false)]

	[TestCase(true, (ushort)0, "key", "key", ExpectedResult = false)]
	public bool AmbientWeatherSettings_IsValid(bool isEnabled, ushort seconds, string apiKey, string applicationKey)
	{
		var settings = new AmbientWeatherSettings()
		{
			EnrichFromAmbientWeatherNetwork = isEnabled,
			UserApiKey = apiKey,
			ApplicationKey = applicationKey,
			PollingFrequencySeconds = seconds
		};

		return settings.IsValid();
	}
}
