FROM microsoft/dotnet:1.0.1-core
ENTRYPOINT ["dotnet", "Dag34.Minor.Chatservice.dll"]
ARG source=source=./bin/Debug/netcoreapp1.0/publish
WORKDIR /app
COPY $source .
