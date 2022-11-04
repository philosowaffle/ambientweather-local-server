using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrus.Wrappers;
using Common.Observe;
using Core.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Core.AmbientWeatherNetwork;
public class AWNBackgroundCollector : BackgroundService
{
	private const string SocketUrl = "https://rt2.ambientweather.net/?api=1";

	private static readonly ILogger _logger = LogContext.ForClass<AWNBackgroundCollector>();

	private readonly ISettingsService _settingsService;
	private readonly IServiceProvider _serviceProvider;

	public AWNBackgroundCollector(ISettingsService settingsService, IServiceProvider serviceProvider)
	{
		_settingsService = settingsService;
		_serviceProvider = serviceProvider;
	}

	protected override Task ExecuteAsync(CancellationToken stoppingToken)
	{
		using (IServiceScope scope = _serviceProvider.CreateScope())
		{
			var cirrus = scope.ServiceProvider.GetRequiredService<ICirrusRealtime>();

			return RunAsync(stoppingToken, cirrus);
		}
	}

	private async Task RunAsync(CancellationToken cancellationToken, ICirrusRealtime cirrus)
	{
		try
		{
			var settings = await _settingsService.GetSettingsAsync();

			if (!settings.AmbientWeatherSettings.EnrichFromAmbientWeatherNetwork)
				return;

			if (string.IsNullOrEmpty(settings.AmbientWeatherSettings.ApplicationKey))
				return;

			cirrus.OnSubscribe += OnSubscribe;
			cirrus.OnDataReceived += OnDataReceived;

			//await cirrus.Subscribe(cancellationToken);
			await cirrus.OpenConnection(cancellationToken);

		} catch (Exception e)
		{
			_logger.Fatal(e, "AWN Socket error");
		}
		//finally
		//{
		//	//await cirrus.Unsubscribe();
		//	await cirrus.CloseConnection();
		//}
	}

	private void OnSubscribe(object sender, OnSubscribeEventArgs args)
	{
		_logger.Verbose("Connected to AWN Socket and subscribed to device {@device}", args.UserDevice);
	}

	private void OnDataReceived(object sender, OnDataReceivedEventArgs args)
	{
		// TODO: start trace activity

		_logger.Verbose("Data Received");

		// args.Device
	}
}
