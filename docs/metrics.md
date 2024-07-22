---
layout: default
title: Metrics
nav_order: 3
---

# Metrics

AmbientWeather Local Server is capable of gathering two forms of metrics:

1. [Local Console](#local-console-metrics) - Stays on your network and receives data directly from your AmbientWeather Console
1. [AmbientWeather Network](#ambientweather-network-metrics) - Scrapes the remote AmbientWeather Network servers for data

## Local Console Metrics

If your AmbientWeather Console supports publishing data to a custom webhook, then you can use this method. To learn more about configuring local metric collection see [Setup AmbientWeather Console]({{ site.baseurl }}{% link install/setup-ambientweather-console.md %}).

### Identifying Local Metrics

Metrics from your local Console can be identified by filtering on `source=local`.

### Local Metrics

The metrics provided by your local Console may vary by model. [AmbientWeather provides](https://github.com/ambient-weather/api-docs/wiki/Device-Data-Specs) the below list of possible data:

Not all measurements in the official API are handled by this server yet. The mapping indicates where the AmbientWeather API is mapped to a Prometheus metric. All Prometheus metrics are prepended with ambientweather_api_.
| API Metric | Prometheus Metric |
|:----------|:------------------|
| winddir - instantaneous wind direction, 0-360º | winddirection_deg |
| windspeedmph - instantaneous wind speed, mph | windspeed_mph |
| windgustmph - max wind speed in the last 10 minutes, mph | windspeed_mph |
| maxdailygust - Maximum wind speed in last day, mph | windspeed_mph |
| windgustdir - Wind direction at which the wind gust occurred, 0-360º | winddirection_deg |
| windspdmph_avg2m - Average wind speed, 2 minute average, mph | windspeed_mph |
| winddir_avg2m - Average wind direction, 2 minute average, mph | windspeed_mph |
| windspdmph_avg10m - Average wind speed, 10 minute average, mph | windspeed_mph |
| winddir_avg10m - Average wind direction, 10 minute average, 0-360º |  winddirection_deg |
| humidity - Outdoor Humidity, 0-100% | humidity_percent |
| humidity1...humidity10 - humidity 1...10, 0-100% | |
humidityin - Indoor Humidity, 0-100%| humidity_percent |
| tempf - Outdoor Temperature, ºF | temperature_f |
| temp1f...temp10f - Temperature 1...10, ºF | temperature_f |
| soiltemp1f...soiltemp10f - Temperature 1...10, ºF | temperature_f |
| soilhum1...soilhum10 - Temperature 1...10, %| soilhum |
| tempinf - Indoor Temperature, ºF | |
| battout - Outdoor Battery - OK/Low indication, Int, 1=OK, 0=Low (Meteobridge Users 1=Low, 0=OK) | lowbattery_bool |
| battin - Indoor Battery - OK/Low indication, Int, 1=OK, 0=Low (Meteobridge Users 1=Low, 0=OK) | lowbattery_bool |
| batt1...batt10 - OK/Low indication, Int, 1=OK, 0=Low (Meteobridge Users 1=Low, 0=OK) | |
| batt_25 - PM2.5 Air Quality Sensor Battery indication, OK/Low indication, Int, 1=OK, 0=Low (Meteobridge Users 1=Low, 0=OK) | |
| batt_lightning - Lightning Detector Battery - 1=Low 0=OK | |
| batleak1...batleak4 - Leak Detector Battery - 1=Low 0=OK | |
| battsm1...battsm4 - Soil Moisture Battery - 1=OK, 0=Low| |
| batt_co2 - CO2 battery - 1=OK, 0=Low| lowbattery_bool |
| batt_cellgateway - Cellular Gateway - 1=OK, 0=Low | |
| hourlyrainin - Hourly Rain Rate, in/hr | rain_in |
| dailyrainin - Daily Rain, in| rain_in |
| 24hourrainin - 24 Hour Rain, in |
| weeklyrainin - Weekly Rain, in| rain_in |
| monthlyrainin - Monthly Rain, in | rain_in |
| yearlyrainin - Yearly Rain, in | rain_in |
| eventrainin - Event Rain, in | rain_in |
| totalrainin - Total Rain, in (since last factory reset) | |
| baromrelin - Relative Pressure, inHg | baromabsin |
| baromabsin - Absolute Pressure, inHg | baromrelin |
| uv - Ultra-Violet Radiation Index, integer on all devices EXCEPT WS-8478. | uv_index |
| solarradiation - Solar Radiation, W/m^2 | solarradiation_wm2 |
| co2 - CO2 Meter, ppm | |
| relay1...relay10 - Relay 1...10, 0 or 1 | |
| pm25 - PM2.5 Air Quality, Float, µg/m^3| |
| pm25_24h - PM2.5 Air Quality 24 hour average, Float, µg/m^3 | |
| pm25_in - PM2.5 Air Quality, Indoor, Float, µg/m^3 | |
| pm25_in_24h - PM2.5 Air Quality 24 hour average, Indoor, Float, µg/m^3 | |
| lightning_day - Lightning strikes per day, int | |
| lightning_hour - Lightning strikes per hour, int| |
| lightning_time - Last strike time, Datetime| |
| lightning_distance - Distance of last lightning strike, Float, miles| |
| tz - IANA Time Zone, String | |
| dateutc - Datetime, int (milliseconds from 01-01-1970, rounded down to nearest minute on server) | |

## AmbientWeather Network Metrics

If your AmbientWeather Console does not support publishing data to a custom webhook, then you can use this method instead to fetch your weather metrics. 

Additionally, some metrics are *only* calculated on the cloud servers and are not available from your local Console. In this case you may also wish to enrich this extra information from the AmbientWeather Network.

To learn more about configuring cloud metric collection see [Setup AmbientWeather Console]({{ site.baseurl }}{% link configuration/json.md %}#ambientweather-config).

### Identifying Cloud Metrics

Metrics scraped from the cloud can be identified by filtering on `source=cloud`.

### Cloud Metrics

The metrics provided by the cloud will vary by model.  Generally, all of the metrics listed under [Local Metrics](#local-metrics) will also be available from the cloud.  [AmbientWeather provides](https://github.com/ambient-weather/api-docs/wiki/Device-Data-Specs) the below list of additional data that is only available from the cloud:

```text

    lastRain - Last time hourlyrainin > 0, date (calculated on server)
    dewPoint - Dew Point, ºF (calculated on server)
    feelsLike - if < 50ºF => Wind Chill, if > 68ºF => Heat Index (calculated on server)
    date - Human Readable Date, string (converted on server from dateutc)
    feelsLike1...feelsLike10 - feelsLike for sensors
    dewPoint1...dewPoint10 - dewPoint for sensors
    feelsLikein - Indoor Feels Like
    dewPointin = Indoor dew Point
```
