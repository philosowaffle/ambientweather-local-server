using Common;
using Common.Observe;
using Core.MetricsHandlers;
using Core.Settings;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Core.AmbientWeatherNetwork;
public class AWNBackgroundCollector : BackgroundService
{
	private static readonly ILogger _logger = LogContext.ForClass<AWNBackgroundCollector>();

	private readonly ISettingsService _settingsService;
	private readonly IApiClient _client;
	private readonly IEnumerable<IMetricsHandler> _metricsHandlers;

	public AWNBackgroundCollector(ISettingsService settingsService, IApiClient client, IEnumerable<IMetricsHandler> metricsHandlers)
	{
		_settingsService = settingsService;
		_client = client;
		_metricsHandlers = metricsHandlers;
	}

	protected override Task ExecuteAsync(CancellationToken stoppingToken)
	{
		return RunAsync(stoppingToken);
	}

	private async Task RunAsync(CancellationToken cancellationToken )
	{
		try
		{
			var settings = await _settingsService.GetSettingsAsync();

			if (!settings.AmbientWeatherSettings.EnrichFromAmbientWeatherNetwork
				|| !settings.AmbientWeatherSettings.IsValid())
				return;

			var apiKey = settings.AmbientWeatherSettings.UserApiKey!;
			var applicationKey = settings.AmbientWeatherSettings.ApplicationKey!;
			var frequency = settings.AmbientWeatherSettings.PollingFrequencySeconds;

			while (!cancellationToken.IsCancellationRequested)
			{
				using (Tracing.Trace($"{nameof(AWNBackgroundCollector)}.{nameof(RunAsync)}"))
				{
					var deviceData = await _client.GetLatestFromDevicesAsync(apiKey, applicationKey);

					var tasks = new List<Task>(_metricsHandlers.Count());
					foreach (var device in deviceData)
					{
						if (device is null || device.LastData is null) continue;
						foreach (var handler in _metricsHandlers)
							tasks.Add(handler.ProcessAsync(device.LastData));
					}

					await Task.WhenAll(tasks);
				}

				Thread.Sleep(frequency * 1000);
			}

		} catch (Exception e)
		{
			_logger.Fatal(e, "AWN Api error");
		}
	}
}
