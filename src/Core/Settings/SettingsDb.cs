using System.Diagnostics;
using Common;
using Common.Database;
using Common.Observe;
using JsonFlatFileDataStore;
using Prometheus;
using Serilog;

namespace Core.Settings;

public interface ISettingsDb
{
	Task<Settings> GetAsync();
	Task<bool> UpsertAsync(Settings settings);
}

public class SettingsDb : DbBase<Settings>, ISettingsDb
{
	private static readonly ILogger _logger = LogContext.ForClass<SettingsDb>();

	private readonly DataStore _db;
	private readonly Settings _defaultSettings = new Settings();

	public SettingsDb(IIoWrapper fileHandler) : base("Settings", fileHandler)
	{
		_db = new DataStore(DbPath);
	}

	public Task<Settings> GetAsync()
	{
		using var metrics = DbMetrics.DbActionDuration.WithLabels("get", DbName).NewTimer();
		using var tracing = Tracing.Trace($"{nameof(SettingsDb)}.{nameof(GetAsync)}");

		try
		{
			return Task.FromResult(_db.GetItem<Settings>("settings"));
		}
		catch (KeyNotFoundException k)
		{
			_logger.Verbose(k, "Settings key not found in DB.");
			tracing?.SetStatus(ActivityStatusCode.Error);
			return Task.FromResult(new Settings());
		}
		catch (Exception e)
		{
			_logger.Error(e, "Failed to get Settings from db");
			tracing?.SetStatus(ActivityStatusCode.Error);
			return Task.FromResult(new Settings());
		}
	}

	public Task<bool> UpsertAsync(Settings settings)
	{
		using var metrics = DbMetrics.DbActionDuration.WithLabels("upsert", DbName).NewTimer();
		using var tracing = Tracing.Trace($"{nameof(SettingsDb)}.{nameof(UpsertAsync)}");

		try
		{
			return _db.ReplaceItemAsync("settings", settings, upsert: true);
		}
		catch (Exception e)
		{
			_logger.Error(e, "Failed to upsert Settings in db");
			tracing?.SetStatus(ActivityStatusCode.Error);
			return Task.FromResult(false);
		}
	}
}
