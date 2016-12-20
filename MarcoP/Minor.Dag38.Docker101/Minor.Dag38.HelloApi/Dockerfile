FROM microsoft/dotnet:1.0.1-core
WORKDIR /app
ARG source=./bin/Debug/netcoreapp1.0/publish
COPY $source .
ENV ASPNETCORE_URLS http://*:80
EXPOSE 80
ENTRYPOINT ["dotnet", "Minor.Dag38.HelloApi.dll"]