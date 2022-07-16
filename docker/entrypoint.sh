#!/bin/bash
set -e

chown -R bt:bt /app
chmod 770 -R /app

if [[ "$1" == "api" ]]; then
    exec runuser -u bt ./Api
elif [[ "$1" == "webui" ]]; then
    exec runuser -u bt ./WebUI
else
   echo "Nothing to do."
fi