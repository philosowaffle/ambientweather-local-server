﻿using Common;
using Common.Observe;
using Core.MetricsHandlers;
using Core.MetricsHandlers.PrometheusMetrics;
using Core.Settings;
using Microsoft.Extensions.Caching.Memory;
using Prometheus;
using Serilog;
using Serilog.Enrichers.Span;
using Serilog.Events;
using System.Reflection;

///////////////////////////////////////////////////////////
/// STATICS
///////////////////////////////////////////////////////////
Statics.AppType = Constants.ApiName;
Statics.MetricPrefix = Constants.ApiName;
Statics.TracingService = Constants.ApiName;

///////////////////////////////////////////////////////////
/// HOST
///////////////////////////////////////////////////////////
var builder = WebApplication.CreateBuilder(args);

builder.Configuration
	.AddJsonFile(Path.Join(Environment.CurrentDirectory, "configuration.local.json"), optional: true, reloadOnChange: true)
	.AddEnvironmentVariables(prefix: Constants.EnvironmentVariablePrefix)
	.AddCommandLine(args);

var config = new AppConfiguration();
ConfigurationSetup.LoadConfigValues(builder.Configuration, config);

builder.WebHost.UseUrls(config.Api.HostUrl);

builder.Host.UseSerilog((ctx, logConfig) =>
{
	logConfig
	.ReadFrom.Configuration(ctx.Configuration, sectionName: $"{nameof(Observability)}:Serilog")
	.Enrich.WithSpan()
	.Enrich.FromLogContext();
});

///////////////////////////////////////////////////////////
/// SERVICES
///////////////////////////////////////////////////////////
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = $"{Constants.ApiName}", Version = "v1" });
	var executingAssembly = Assembly.GetExecutingAssembly();
	var referencedAssemblies = executingAssembly.GetReferencedAssemblies();
	var docPaths = referencedAssemblies
					.Union(new AssemblyName[] { executingAssembly.GetName() })
					.Select(a => Path.Combine(AppContext.BaseDirectory, $"{a.Name}.xml"))
					.Where(f => File.Exists(f)).ToArray();
	foreach (var docPath in docPaths)
		c.IncludeXmlComments(docPath);
});

// CACHE
builder.Services.AddSingleton<IMemoryCache, MemoryCache>();

// HANDLERS
builder.Services.AddTransient<IMetricsHandler, PrometheusHandler>();

// SETTINGS
builder.Services.AddSingleton<ISettingsService, SettingsService>();
builder.Services.AddSingleton<ISettingsCache, SettingsCache>();
builder.Services.AddSingleton<ISettingsDb, SettingsDb>();

// IO & CONFIG
builder.Services.AddSingleton<IIoWrapper, IoWrapper>();

FlurlConfiguration.Configure(config.Observability);
Tracing.EnableApiTracing(builder.Services, config.Observability.Traces);

Log.Logger = new LoggerConfiguration()
				.ReadFrom.Configuration(builder.Configuration, sectionName: $"{nameof(Observability)}:Serilog")
				.Enrich.FromLogContext()
				.CreateLogger();

Logging.LogSystemInformation();
Common.Observe.Metrics.CreateAppInfo();

///////////////////////////////////////////////////////////
/// APP
///////////////////////////////////////////////////////////

var app = builder.Build();

// Setup initial Tracing Source
Tracing.Source = new(Statics.TracingService);

app.UseCors(options =>
{
	options
	.SetIsOriginAllowed((_) => true)
	.AllowAnyHeader();
});

app.UseSwagger();
app.UseSwaggerUI();

if (Log.IsEnabled(LogEventLevel.Verbose))
	app.UseSerilogRequestLogging();

app.Use(async (context, next) =>
{
	await next.Invoke();
});

if (config.Observability.Metrics.Enabled)
{
	Log.Information("Metrics Enabled");
	Common.Observe.Metrics.EnableCollector(config.Observability.Metrics);

	app.MapMetrics();
	app.UseHttpMetrics();
}

app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
