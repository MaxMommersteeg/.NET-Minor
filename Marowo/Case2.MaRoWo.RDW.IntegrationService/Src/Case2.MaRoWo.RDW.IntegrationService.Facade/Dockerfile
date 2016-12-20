FROM microsoft/aspnetcore:1.0.1
ENTRYPOINT ["dotnet", "Case2.MaRoWo.RDW.IntegrationService.Facade.dll"]
ARG source=.
WORKDIR /app
EXPOSE 80
COPY $source .
