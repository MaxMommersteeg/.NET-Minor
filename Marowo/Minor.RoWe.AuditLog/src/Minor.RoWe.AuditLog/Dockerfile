FROM microsoft/dotnet:1.0.1-core
ENTRYPOINT ["dotnet", "Minor.RoWe.AuditLog.dll"]
ARG source=.
WORKDIR /app
COPY $source .
