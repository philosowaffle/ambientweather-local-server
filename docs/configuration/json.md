---
layout: default
title: JSON Config File
parent: Configuration
nav_order: 0
---

# Json Config File

The config file is organized into the below sections.

| Section      | Platforms | Description       |
|:-------------|:----------|:------------------|
| [AmbientWeather Config](#ambientweather-config) | All | This section provides settings related to the AmbientWeather Network and scraping data from the cloud. |
| [Observability Config](#observability-config) | All | This section provides settings related to Metrics, Logs, and Traces for monitoring purposes. |

## AmbientWeather Config

AmbientWeather Local Server can also enrich additional data from the AmbientWeather Network. Some data is only calculated on the AmbientWeather cloud server and is not published by the local Console. To get this information, you need to enable enrichment in this section.

```json
"AmbientWeather": {
  "EnrichFromAmbientWeatherNetwork": true,
  "UserApiKey": "<your api key>",
  "ApplicationKey": "<your application key>",
  "PollingFrequencySeconds": 60
}
```

| Field      | Required | Default | Description |
|:-----------|:---------|:--------|:------------|
| EnrichFromAmbientWeatherNetwork | no | `false` | Whether or not to scrape the cloud and enrich additional metrics. [Learn more]({{ site.baseurl }}{% link metrics.md %}). |
| UserApiKey | yes (if enrichment is enabled) | `null` | Your AmbientWeather [User API key](#user-api-key). |
| ApplicationKey | yes (if enrichment is enabled) | `null` | Your AmbientWeather [Application key](#application-key). |
| PollingFrequencySeconds | no | `60` | How frequently, in seconds, to scrape data from the AmbientWeather Network. |

### User Api Key

You will have to generate a new Api key (also referred to as a Device Key) for AmbientWeather Local Server to use.  To generate this key:

1. [Login to your AmbientWeather.net account settings](https://ambientweather.net/account)
1. Near the bottom of your `Account Settings` page, look for the `API Keys` section
1. Click `Create API Key`
1. Give your new a key a friendly name in the `Label` column and save
1. This will be your User API Key

### Application Key

You will have to generate a new Application key for AmbientWeather Local Server to use.  To generate this key:

1. [Login to your AmbientWeather.net account settings](https://ambientweather.net/account)
1. Near the bottom of your `Account Settings` page, look for the `API Keys` section
1. Near the bottom of this section, look for 
  > Developers: An Application Key is also required for each application that you develop. Click here to create one.
1. Click on the link in that message
1. Type anything in the provided text box, then click `Create Application Key`
1. Give your new a key a friendly name in the `Label` column and save
1. This will be your Application Key

## Observability Config

AmbientWeather Local Server supports publishing OpenTelemetry Metrics, Logs, and Trace. This section provides settings related to those pillars.

The Observability config section contains three main sub-sections:

1. [Metrics](#metrics-config) - Metrics
1. [Traces](#traces-config) - Traces
1. [Serilog](#serilog-config) - Logs

```json
"Observability": {

    "Metrics": {
      "Enabled": false
    },

    "Traces": {
      "Enabled": false,
      "AgentHost": "localhost",
      "AgentPort": 6831
    },

    "Serilog": {
      "Using": [ "Serilog.Sinks.Console", "Serilog.Sinks.File" ],
      "MinimumLevel": "Information",
      "WriteTo": [
        { "Name": "Console" },
        {
          "Name": "File",
          "Args": {
            "path": "./output/log.txt",
            "rollingInterval": "Day",
            "retainedFileCountLimit": 7
          }
        }
      ]
    }
  }
```

### Metrics Config

```json
"Metrics": {
      "Enabled": false
    }
```

| Field      | Required | Default | Description |
|:-----------|:---------|:--------|:------------|
| Enabled | no | `false` | Whether or not to expose metrics. Metrics will be available at `http://localhost:8080/metrics` |

If you are using Docker, ensure you have exposed the port from your container.

#### Example Prometheus scraper config

```yaml
- job_name: 'ambientweather'
    scrape_interval: 60s
    static_configs:
      - targets: [<ambientWeatherLocalServerIPaddress>:<ambientWeatherLocalServerPort>]
    tls_config:
      insecure_skip_verify: true
```

### Traces Config

```json
"Traces": {
      "Enabled": false,
      "AgentHost": "localhost",
      "AgentPort": 6831
    }
```

| Field      | Required | Default | Description |
|:-----------|:---------|:--------|:------------|
| Enabled | no | `false` | Whether or not to generate traces. |
| AgentHost | **yes - if Enalbed=true** | `null` | The host address for your trace collector. |
| AgentPort | **yes - if Enabled=true** | `null` | The port for your trace collector. |

### Serilog Config

```json
"Serilog": {
      "Using": [ "Serilog.Sinks.Console", "Serilog.Sinks.File", "Serilog.Sinks.Grafana.Loki" ],
      "MinimumLevel": {
        "Default": "Information",
        "Override": {
          "Microsoft": "Error",
          "System": "Error"
        }
      },
      "WriteTo": [
        { "Name": "Console" },
        {
          "Name": "File",
          "Args": {
            "path": "./output/log.txt",
            "rollingInterval": "Day",
            "retainedFileCountLimit": 7
          }
        },
        {
          "Name": "GrafanaLoki",
          "Args": {
            "uri": "http://192.168.1.95:3100",
            "textFormatter": "Serilog.Sinks.Grafana.Loki.LokiJsonTextFormatter, Serilog.Sinks.Grafana.Loki",
            "labels": [
              {
                "key": "app",
                "value": "p2g"
              }
            ]
          }
        }]
}
```

| Field      | Required | Default | Description |
|:-----------|:---------|:--------|:------------|
| Using | no | `null` | A list of sinks you would like use. The valid sinks are listed in the example above. |
| MinimumLevel | no | `null` | The minimum level to write. `[Verbose, Debug, Information, Warning, Error, Fatal]` |
| WriteTo | no | `null` | Additional config for various sinks you are writing to. |

More detailed information about configuring Logging can be found on the [Serilog Config Repo](https://github.com/serilog/serilog-settings-configuration#serilogsettingsconfiguration--).
