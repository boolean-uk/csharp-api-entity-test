FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

EXPOSE 5045
EXPOSE 7235


# build my app as Release
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["workshop.wwwapi/workshop.wwwapi.csproj", "exercise.wwwapi/"]
RUN dotnet restore "./workshop.wwwapi/workshop.wwwapi.csproj"
COPY . .
WORKDIR "/src/workshop.wwwapi"
RUN dotnet build "./workshop.wwwapi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./workshop.wwwapi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "workshop.wwwapi.dll"