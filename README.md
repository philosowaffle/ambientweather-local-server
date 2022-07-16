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