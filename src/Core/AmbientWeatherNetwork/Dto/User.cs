using System.Text.Json.Serialization;

namespace Core.AmbientWeatherNetwork.Dto;

public record UserDevice
{
	/// <summary>
	/// Weather Station Mac Address
	/// </summary>
	public string? MacAddress { get; init; }

	/// <summary>
	/// Instance of <see cref="Info"/> class
	/// </summary>
	public Info? Info { get; init; }

	/// <summary>
	/// Instance of <see cref="Device"/> class
	/// </summary>
	public Device? LastData { get; init; }

	/// <summary>
	/// The API Key used for the subscribe command
	/// </summary>
	public string? ApiKey { get; init; }
}

public record Geo
{
	/// <summary>
	/// The Type of Geo Coordinates. i.e. "Point"
	/// </summary>
	public string? Type { get; init; }

	/// <summary>
	/// A list of doubles containing the lat/lon coordinates
	/// coordinates[0] is longitude
	/// coordinates[1] is latitude
	/// </summary>
	public IReadOnlyList<double>? Coordinates { get; init; }
}

public record Coords
{
	/// <summary>
	/// Latitude of the weather station
	/// </summary>
	[JsonPropertyName("lat")]
	public double Latitude { get; init; }

	/// <summary>
	/// Longitude of the weather station
	/// </summary>
	[JsonPropertyName("lon")]
	public double Longitude { get; init; }
}

public record Location
{
	[JsonPropertyName("coords")]
	public Coords? Coordinates { get; init; }

	public string? Address { get; init; }
	/// <summary>
	/// Short location name, possibly just City.
	/// </summary>
	[JsonPropertyName("location")]
	public string? LocationName { get; init; }
	public double Elevation { get; init; }
	public Geo? Geo { get; init; }
}

public record Info
{
	/// <summary>
	/// The name of the weather station configured in the AmbientWeather dashboard
	/// </summary>
	public string? Name { get; init; }

	[JsonPropertyName("coords")]
	public Location? Location { get; init; }
}
