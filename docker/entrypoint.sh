#!/bin/bash
set -e

chown -R awuser:awuser /app
chmod 770 -R /app

if [[ "$1" == "api" ]]; then
    exec runuser -u awuser ./api/Api
elif [[ "$1" == "pyroscope" ]]; then
    echo Launching with Pyroscope
    exec pyroscope exec -spy-name dotnetspy ./api/Api
else
   echo "Nothing to do."
fi