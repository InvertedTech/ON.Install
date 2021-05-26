# Test dockerfile to test on Raspberry PI
# Base for Debian ARM Linux
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim-arm32v7 AS base
# Setting working directory
WORKDIR /app
# Copy the files from Release Folder to working directory
COPY ./bin/Release/net5.0/. /app/
# Entrypoint of the app.
ENTRYPOINT ["dotnet", "NodeF.SimpleAuth.dll"]