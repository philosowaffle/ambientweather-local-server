using Common;
using Common.Observe;
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
Label.LabelPrefix = Constants.ApiName;

///////////////////////////////////////////////////////////
/// HOST
///////////////////////////////////////////////////////////
var builder = WebApplication.CreateBuilder(args);

var configProvider = builder.Configuration.AddJsonFile(Path.Join(Environment.CurrentDirectory, "configuration.local.json"), optional: true, reloadOnChange: true)
				.AddEnvironmentVariables(prefix: Constants.EnvironmentVariablePrefix)
				.AddCommandLine(args)
				.Build();

var config = new AppConfiguration();
builder.Configuration.GetSection("Api").Bind(config.Api);
builder.Configuration.GetSection(nameof(Observability)).Bind(config.Observability);
builder.Configuration.GetSection(nameof(Developer)).Bind(config.Developer);

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

Log.Logger = new LoggerConfiguration()
				.ReadFrom.Configuration(builder.Configuration, sectionName: $"{nameof(Observability)}:Serilog")
				.Enrich.FromLogContext()
				.CreateLogger();

FlurlConfiguration.Configure(config.Observability);
Tracing.EnableTracing(builder.Services, config.Observability.Traces);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = $"{Constants.ApiName}", Version = "v1" });
	var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// CACHE
builder.Services.AddSingleton<IMemoryCache, MemoryCache>();

// SETTINGS
builder.Services.AddSingleton<ISettingsService, SettingsService>();
builder.Services.AddSingleton<ISettingsCache, SettingsCache>();
builder.Services.AddSingleton<ISettingsDb, SettingsDb>();

// IO & CONFIG
builder.Services.AddSingleton<IIoWrapper, IoWrapper>();
builder.Services.AddSingleton<AppConfiguration>((serviceProvider) =>
{
	var config = new AppConfiguration();
	builder.Configuration.GetSection("Api").Bind(config.Api);
	builder.Configuration.GetSection(nameof(Observability)).Bind(config.Observability);
	builder.Configuration.GetSection(nameof(Developer)).Bind(config.Developer);
	return config;
});

var runtimeVersion = Environment.Version.ToString();
var os = Environment.OSVersion.Platform.ToString();
var osVersion = Environment.OSVersion.VersionString;
var version = Constants.AppVersion;

Prometheus.Metrics.CreateGauge(Label.BuildInfo, "Build info for the running instance.", new GaugeConfiguration()
{
	LabelNames = new[] { Label.Version, Label.Os, Label.OsVersion, Label.DotNetRuntime }
}).WithLabels(version, os, osVersion, runtimeVersion)
.Set(1);

Log.Debug("Api Version: {@Version}", version);
Log.Debug("Operating System: {@Os}", osVersion);
Log.Debug("DotNet Runtime: {@DotnetRuntime}", runtimeVersion);

///////////////////////////////////////////////////////////
/// APP
///////////////////////////////////////////////////////////

var app = builder.Build();

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
	using var tracing = Tracing.Trace($"{nameof(Program)}.Entrypoint");
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