FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY itransitionFakeDataGenerator/*.csproj .
RUN dotnet restore
COPY itransitionFakeDataGenerator/ .
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "itransitionFakeDataGenerator.dll"]
