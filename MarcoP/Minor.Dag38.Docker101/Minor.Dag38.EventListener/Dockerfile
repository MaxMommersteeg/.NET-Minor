FROM microsoft/dotnet:1.0.1-core
ENTRYPOINT ["dotnet", "Minor.Dag38.EventListener.dll"]
ARG source=.
WORKDIR /app
COPY $source .
