#!/bin/bash
set -e

chown -R awuser:awuser /app
chmod 770 -R /app

if [[ "$1" == "api" ]]; then
    exec runuser -u awuser ./api/Api
elif [[ "$1" == "webui" ]]; then
    exec runuser -u awuser ./webui/WebUI
else
   echo "Nothing to do."
fi