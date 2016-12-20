FROM microsoft/dotnet:1.0.1-core
WORKDIR /app
ARG source=./bin/Debug/netcoreapp1.0
COPY $source .
ENTRYPOINT ["dotnet", "Minor.Dag38.HelloApp.dll"]