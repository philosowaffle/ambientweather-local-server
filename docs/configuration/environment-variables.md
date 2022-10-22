---
layout: default
title: Environment Variables
parent: Configuration
nav_order: 1
---

# Environment Variable Configuration

All of the values defined in the [Json config file]({{ site.baseurl }}{% link configuration/json.md %}) can also be defined as environment variables. This functionality is provided by the default dotnet [IConfiguration interface](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-5.0#environment-variables-1).

The variables use the following convention, note the use of both single and double underscores:

```bash
AMBIENTWEATHER_CONFIGSECTION__CONFIGPROPERTY=value

AMBIENTWEATHER_OBSERVABILITY__METRICS__ENABLED=true
```
