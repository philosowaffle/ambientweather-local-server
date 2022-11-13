using Common;
using Common.Observe;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Core.Settings;

public class FileBasedSettingsService : ISettingsService
{
	private const string SettingsKey = "Settings";

	private static readonly ILogger _logger = LogContext.ForClass<FileBasedSettingsService>();
	private static readonly object _lock = new object();

	private readonly IConfiguration _configurationLoader;
	private readonly IMemoryCache _cache;

	public FileBasedSettingsService(IConfiguration configurationLoader, IMemoryCache cache)
	{
		_configurationLoader = configurationLoader;
		_cache = cache;
	}

	public Task<AppConfiguration> GetSettingsAsync()
	{
		using var tracing = Tracing.Trace($"{nameof(FileBasedSettingsService)}.{nameof(GetSettingsAsync)}");

		lock (_lock)
		{
			return _cache.GetOrCreateAsync(SettingsKey, (cacheEntry) =>
			{
				cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(15);
				var settings = new AppConfiguration();
				ConfigurationSetup.LoadConfigValues(_configurationLoader, settings);

				return Task.FromResult(settings);
			});
		}
	}
}
