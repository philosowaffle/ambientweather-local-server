---
layout: default
title: Configure AmbientWeather Console
parent: Install
nav_order: 2
---

# Configure AmbientWeather Console

Some models of AmbientWeather console's support publishing data to a configured HTTP endpoint.  If your model supports this, then you can use `ambientweather-local-server` to receive this data.

## 1. Console Firmware

First step is to update your AmbientWeather Console firmware to the latest version.

[Firmware update instructions](https://ambientweather.com/faqs/question/view/id/1415/)

|  Model  | Min Firmware Version |
|:--------|----------------------|
| WS-2000 | 1.7.6 |

## 2. Console Wifi Firmware

Additionally, the AmbientWeather Console has Wifi firmware that should be updated to the latest version.

[Wifi Firmware update instructions](https://ambientweather.com/faqs/question/view/id/1449/)

|  Model   | Min Wifi Firmware Version |
|:---------|---------------------------|
| WS-2000  | 4.3.2 |
| WS-2902A | 4.3.4 |

## 3. Configure Custom Server

1. On your AmbientWeather Console find where you can configure a custom server
    1. IP Address will be the IP Address of your locally running `ambientweather-local-server`
    1. Port will be the port of your locally running `ambientweather-local-server` ex. 8080 by default
    1. Path should be: `/api/ambientweather/metrics?`
        1. The question mark at the end is required
1. Save your settings
1. Your AmbientWeather Console should now be pushing data to your `ambientweather-local-server`
