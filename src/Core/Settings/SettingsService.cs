namespace Core.Settings;

public interface ISettingsService
{
	Task<Settings> GetAsync();
	Task<bool> UpsertAsync(Settings settings);
}

public class SettingsService : ISettingsService
{
	private ISettingsCache _cache;

	public SettingsService(ISettingsCache cache)
	{
		_cache = cache;
	}

	public Task<Settings> GetAsync()
	{
		return _cache.GetAsync();
	}

	public Task<bool> UpsertAsync(Settings settings)
	{
		return _cache.UpsertAsync(settings);
	}
}