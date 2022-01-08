FROM arm32v7/debian:buster-slim

RUN apt-get update \
    && apt-get install -y --no-install-recommends \
    ca-certificates \
    \
    # .NET Core dependencies
    libc6 \
    libgcc1 \
    libgssapi-krb5-2 \
    libssl1.1 \
    libstdc++6 \
    zlib1g \
    wget \
    && rm -rf /var/lib/apt/lists/*

ENV \
    # Configure web servers to bind to port 80 when present
    ASPNETCORE_URLS=http://+:80 \
    # Enable detection of running in a container
    DOTNET_RUNNING_IN_CONTAINER=true \
    # Set the invariant mode since icu-libs isn't included (see https://github.com/dotnet/announcements/issues/20)
    DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true \
    # ASP.NET Core version
    ASPNET_VERSION=6.0.0 \
    # Set the default console formatter to JSON
    Logging__Console__FormatterName=Json

ENV DOTNET_VERSION=6.0.0

RUN wget -O aspnetcore.tar.gz https://dotnetcli.azureedge.net/dotnet/aspnetcore/Runtime/$DOTNET_VERSION/aspnetcore-runtime-$DOTNET_VERSION-linux-arm.tar.gz \
    && aspnetcore_sha512='36be738bb40a0cadacd4531c3597a25fd45deb7c48090ffb61c79a5db7742a5b8e13051b06556e15e7e162e4a044795c0ca5e6da4db26b63b05c37b39e74e301' \
    && echo "$aspnetcore_sha512  aspnetcore.tar.gz" | sha512sum -c - \
    && mkdir -p /usr/share/dotnet \
    && tar -C /usr/share/dotnet -oxzf aspnetcore.tar.gz \
    && ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet \
    && rm aspnetcore.tar.gz
