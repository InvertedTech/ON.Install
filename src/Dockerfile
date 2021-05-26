FROM mcr.microsoft.com/dotnet/sdk:5.0 as builder  
ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

RUN mkdir -p /root/src/app  
WORKDIR /root/src/app  
COPY NodeF.Fragment     NodeF.Fragment 
COPY NodeF.SimpleAuth     NodeF.SimpleAuth  

WORKDIR /root/src/app/NodeF.Fragment
RUN dotnet restore ./NodeF.Fragment.csproj 
RUN dotnet build ./NodeF.Fragment.csproj

WORKDIR /root/src/app/NodeF.SimpleAuth
RUN dotnet restore ./NodeF.SimpleAuth.csproj  
RUN dotnet publish -c release -o published -r linux-arm

FROM mcr.microsoft.com/dotnet/runtime:5.0-buster-slim-arm32v7

WORKDIR /root/  
COPY --from=builder /root/src/app/NodeF.SimpleAuth/published .

CMD ["dotnet", "./NodeF.SimpleAuth.dll"]