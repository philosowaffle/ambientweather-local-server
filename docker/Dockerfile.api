###################
# CREATE FINAL LAYER
###################
FROM mcr.microsoft.com/dotnet/aspnet:6.0 as final

ENV PYTHONUNBUFFERED=1
RUN apt-get update \
	&& apt-get -y install bash tzdata \
	&& apt-get purge -y -f --force-yes $EXT_BUILD_DEPS \
	&& apt-get autoremove -y \
	&& apt-get clean
	&& rm -rf /var/lib/apt/lists/* \

RUN groupadd -g 1017 awuser && useradd -g awuser -u 1017 awuser

WORKDIR /app

RUN mkdir -m770 {data}

###################
# BUILD LAYER
###################
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

COPY . /build
WORKDIR /build

SHELL ["/bin/bash", "-c"]

ARG TARGETPLATFORM
ARG VERSION

RUN echo $TARGETPLATFORM \
	&& echo $VERSION
ENV VERSION=${VERSION}

###################
# BUILD API
###################
RUN if [[ "$TARGETPLATFORM" = "linux/arm64" ]] ; then \
		dotnet publish /build/src/Api/Api.csproj -c Release -r linux-arm64 -o /build/published/api --version-suffix $VERSION --self-contained ; \
	else \
		dotnet publish /build/src/Api/Api.csproj -c Release -r linux-x64 -o /build/published/api --version-suffix $VERSION --self-contained ; \
	fi

###################
# FINAL
###################
FROM final

COPY --from=build /build/LICENSE ./LICENSE

COPY --from=build /build/published/api ./api

COPY --from=build /build/api.configuration.example.json ./api/configuration.local.json

COPY --chmod=770 ./docker/entrypoint.sh .

EXPOSE 8080 8443
ENTRYPOINT ["/app/entrypoint.sh"]
CMD ["api"]