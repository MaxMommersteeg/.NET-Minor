FROM microsoft/aspnetcore:1.0.1
ENTRYPOINT ["dotnet", "Minor.Dag57.TFSBuild.dll"]
ARG source=.
WORKDIR /app
EXPOSE 80
COPY $source .
