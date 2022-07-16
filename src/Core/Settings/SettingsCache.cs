using Common.Observe;
using Microsoft.Extensions.Caching.Memory;
using Prometheus;
using Serilog;

namespace Core.Settings;

public interface ISettingsCache
{
	Task<Settings> GetAsync();
	Task<bool> UpsertAsync(Settings settings);
}

public class SettingsCache : ISettingsCache
{
	private static readonly ILogger _logger = LogContext.ForClass<SettingsCache>();
	private readonly IMemoryCache _cache;
	private readonly ISettingsDb _database;

	private const string KEY = "setttings";
	private static readonly object _lock = new object();

	public SettingsCache(IMemoryCache cache, ISettingsDb database)
	{
		_cache = cache;
		_database = database;
	}

	public Task<Settings> GetAsync()
	{
		using var metrics = CacheMetrics.CacheActionDuration
									.WithLabels(nameof(SettingsCache), "get")
									.NewTimer();
		using var tracing = Tracing.Trace($"{nameof(SettingsCache)}.{nameof(GetAsync)}");

		lock (_lock)
		{
			return _cache.GetOrCreateAsync(KEY, cacheEntry =>
			{
				tracing.AddTag("cache", "miss");
				cacheEntry.SetPriority(CacheItemPriority.NeverRemove);
				return _database.GetAsync();
			});
		}
	}

	public async Task<bool> UpsertAsync(Settings settings)
	{
		using var metrics = CacheMetrics.CacheActionDuration
									.WithLabels(nameof(SettingsCache), "upsert")
									.NewTimer();
		using var tracing = Tracing.Trace($"{nameof(SettingsCache)}.{nameof(UpsertAsync)}");

		var updated = await _database.UpsertAsync(settings);
		if (updated)
		{
			lock (_lock)
			{
				try
				{
					_cache.Set(KEY, settings);
				}
				catch (Exception e)
				{
					_logger.Error("Failed to update Settings mem cache. Clearing cache.", e);
					tracing.SetStatus(System.Diagnostics.ActivityStatusCode.Error);
				}
				finally
				{
					_cache.Remove(KEY);
				}
			}
		}

		return updated;
	}
}