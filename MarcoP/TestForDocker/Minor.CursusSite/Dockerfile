FROM microsoft/dotnet:1.0.1-core
WORKDIR /app
ENV ASPNETCORE_URLS http://*:80
EXPOSE 80
ENTRYPOINT ["dotnet", "Minor.CursusSite.dll"]
COPY . /app
