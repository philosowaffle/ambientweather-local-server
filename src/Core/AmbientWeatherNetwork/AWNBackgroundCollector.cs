using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Observe;
using Core.Settings;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Core.AmbientWeatherNetwork;
public class AWNBackgroundCollector : BackgroundService
{
	private static readonly ILogger _logger = LogContext.ForClass<AWNBackgroundCollector>();

	private readonly ISettingsService _settingsService;

	public AWNBackgroundCollector(ISettingsService settingsService)
	{
		_settingsService = settingsService;
	}

	protected override Task ExecuteAsync(CancellationToken stoppingToken)
	{
		return RunAsync(stoppingToken);
	}

	private async Task RunAsync(CancellationToken cancellationToken)
	{

	}
}
