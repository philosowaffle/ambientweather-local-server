namespace Core.GitHub.Dto;

public struct AmbientWeatherServerLatestRelease
{
	public string? LatestVersion { get; set; }
	public DateTime ReleaseDate { get; set; }
	public string? ReleaseUrl { get; set; }
	public string? Description { get; set; }
	public bool IsReleaseNewerThanInstalledVersion { get; set; }
}
