﻿using Common;
using Common.Observe;
using MudBlazor.Services;
using Prometheus;
using Serilog;
using Serilog.Enrichers.Span;
using Serilog.Events;
using WebUI;

///////////////////////////////////////////////////////////
/// STATICS
///////////////////////////////////////////////////////////
///
Label.LabelPrefix = Constants.WebUIName;

///////////////////////////////////////////////////////////
/// HOST
///////////////////////////////////////////////////////////

var builder = WebApplication.CreateBuilder(args);

var configProvider = builder.Configuration.AddJsonFile(Path.Join(Environment.CurrentDirectory, "configuration.local.json"), optional: true, reloadOnChange: true)
                .AddEnvironmentVariables(prefix: Constants.EnvironmentVariablePrefix)
                .AddCommandLine(args)
                .Build();

var apiSettings = new ApiSettings();
builder.Configuration.GetSection("Api").Bind(apiSettings);

var config = new AppConfiguration();
builder.Configuration.GetSection("Api").Bind(config.Api);
builder.Configuration.GetSection(nameof(Observability)).Bind(config.Observability);
builder.Configuration.GetSection(nameof(Developer)).Bind(config.Developer);

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

Tracing.EnableWebUITracing(builder.Services, config.Observability.Traces);
FlurlConfiguration.Configure(config.Observability, 20);

builder.Services.AddScoped<IApiClient>(sp => new ApiClient(apiSettings.HostUrl));
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var runtimeVersion = Environment.Version.ToString();
var os = Environment.OSVersion.Platform.ToString();
var osVersion = Environment.OSVersion.VersionString;
var version = Constants.AppVersion;

Prometheus.Metrics.CreateGauge(Label.BuildInfo, "Build info for the running instance.", new GaugeConfiguration()
{
    LabelNames = new[] { Label.Version, Label.Os, Label.OsVersion, Label.DotNetRuntime }
}).WithLabels(version, os, osVersion, runtimeVersion)
.Set(1);

Log.Debug("WebUI Version: {@Version}", version);
Log.Debug("Operating System: {@Os}", osVersion);
Log.Debug("DotNet Runtime: {@DotnetRuntime}", runtimeVersion);

///////////////////////////////////////////////////////////
/// APP
///////////////////////////////////////////////////////////

var app = builder.Build();

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

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

await app.RunAsync();
