FROM mcr.microsoft.com/dotnet/sdk:5.0
RUN wget https://packages.microsoft.com/config/debian/10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
	dpkg -i packages-microsoft-prod.deb && \
	rm packages-microsoft-prod.deb && \
    apt-get update && \
    apt-get install -y apt-transport-https && \
    apt-get update && \
    apt-get install -y dotnet-sdk-3.1
RUN dotnet tool install -g Microsoft.Tye --version "0.10.0-alpha.21420.1"
RUN curl -fsSL https://get.docker.com -o get-docker.sh
RUN sh get-docker.sh
ENV PATH "$PATH:/root/.dotnet/tools"

