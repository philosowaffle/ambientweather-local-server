---
layout: default
title: Configuration
nav_order: 2
has_children: true
---

# Configuration

AmbientWeather Local Server supports configuration via [command line arguments]({{ site.baseurl }}{% link configuration/command-line.md %}), [environment variables]({{ site.baseurl }}{% link configuration/environment-variables.md %}), [json config file]({{ site.baseurl }}{% link configuration/json.md %}), and via the user interface. By default, the server looks for a file named `configuration.local.json` in the same directory where it is run.

## Example working config

1. [Api config](https://github.com/philosowaffle/ambientweather-local-server/blob/main/api.configuration.example.json)

## Config Precedence

The following defines the precedence in which config definitions are honored. With the first item overriding any below it.

1. Command Line
1. Environment Variables
1. Config File

For example, if you defined a setting ONLY in the Config file, then the Config file setting will be used.

If you defined a setting in both the Config file AND the Environment variables, then the Environment variable setting will be used.

If you defined a setting using all 3 methods (config file, env, and command line), then the setting provided via the command line will be used.
