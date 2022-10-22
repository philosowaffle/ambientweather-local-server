---
layout: default
title: Docker
parent: Install
nav_order: 0
---

# Docker

The recommended installation method is with Docker.

## docker-compose

*Pre-requisite:* You have either `docker-compose` or `Docker Desktop` installed

1. Create a directory `ambientweather-local-server`
    1. Inside this folder create a [docker-compose.yaml](https://github.com/philosowaffle/ambientweather-local-server/blob/main/docker/docker-compose.yaml) file in the directory
    1. Also create a [configuration.local.json](https://github.com/philosowaffle/ambientweather-local-server/blob/main/api.configuration.example.json) file in the directory.
1. Open a terminal in this folder
1. Run: `docker-compose pull && docker-compose up -d`

You can learn more about customizing your configuration over in the [Configuration Section]({{ site.baseurl }}{% link configuration/index.md %})

### To stop the server

1. You can use Docker Desktop application to kill the containers
1. Or, you can open a terminal in the `ambientweather-local-server` folder
    1. Run: `docker-compose down`

### To update the server

1. Open a terminal in the `ambientweather-local-server` folder
    1. Run: `docker-compose pull && docker-compose up -d`

## Repositories

### DockerHub

[DockerHub](https://hub.docker.com/r/philosowaffle/ambientweather-local-server)

```bash
docker run -v /full/path/to/configuration.local.json:/app/configuration.local.json -v /full/path/to/output:/app/output philosowaffle/ambientweather-local-server:stable
```

### GitHub Package

[GitHub Package](https://github.com/philosowaffle/ambientweather-local-server/pkgs/container/ambientweather-local-server)

```bash
docker run -v /full/path/to/configuration.local.json:/app/configuration.local.json -v /full/path/to/output:/app/output ghcr.io/philosowaffle/ambientweather-local-server:stable
```

## Tags

1. `stable` - Always points to the latest release
1. `latest` - The bleeding edge of the master branch, breaking changes may happen
1. `vX.Y.Z` - For using a specific released version

## Docker User

The images run the process under the user and group `awuser:awuser` with uid and gid `1017:1017`.  To access files created by `awuser`:

1. Create a group on the local machine `awuser` with group id `1017`
1. Add your user on the local machine to the `awuser` group
