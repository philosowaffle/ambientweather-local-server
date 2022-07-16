# AmbientWeather Local Server

I local server for recieving AmbientWeather metrics directly from the Console on your local network and exposing these as Prometheus Metrics.

## Notes

1. Tested with the WS-2000
1. Requires Console Firmware version 1.7.6 or later [instructions](https://ambientweather.com/faqs/question/view/id/1415/)
1. Requires Console Wifi Firmware version 4.3.2 or later [instructions](https://ambientweather.com/faqs/question/view/id/1449/)
1. Configure Console to communicate with custom server
	1. IP address of your docker container
	1. Port of your docker container
	1. Path = `/api/ambientweather/metrics?` - the question mark is important

[AWNet Protocol](https://ambientweather.com/faqs/question/view/id/1857/)

Sample WS-2000 request
```
http://localhost:8021/api/ambientweather/metrics?stationtype=AMBWeatherV4.3.3&PASSKEY=C4:5B:BE:5C:FC:84&dateutc=2022-07-16+16:43:05&tempinf=79.0&battin=1&humidityin=51&baromrelin=29.345&baromabsin=29.345&tempf=92.8&battout=1&humidity=48&winddir=115&winddir_avg10m=251&windspeedmph=0.7&windspdmph_avg10m=1.8&windgustmph=5.8&maxdailygust=8.1&hourlyrainin=0.000&eventrainin=0.059&dailyrainin=0.000&weeklyrainin=0.079&monthlyrainin=0.079&yearlyrainin=0.079&solarradiation=727.72&uv=7&batt_co2=1
```