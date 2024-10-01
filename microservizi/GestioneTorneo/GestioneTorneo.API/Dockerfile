# Vedere https://aka.ms/customizecontainer per informazioni su come personalizzare il contenitore di debug e su come Visual Studio usa questo Dockerfile per compilare le immagini per un debug più rapido.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG MOONLIGHT735_NUGET_USERNAME
ARG MOONLIGHT735_NUGET_PASSWORD
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NuGet.config", "."]
COPY ["GestioneTorneo.API/GestioneTorneo.API.csproj", "GestioneTorneo.API/"]
COPY ["GestioneTorneo.Business/GestioneTorneo.Business.csproj", "GestioneTorneo.Business/"]
COPY ["GestioneTorneo.Repository/GestioneTorneo.Repository.csproj", "GestioneTorneo.Repository/"]
COPY ["GestioneTorneo.Shared/GestioneTorneo.Shared.csproj", "GestioneTorneo.Shared/"]
# RUN dotnet restore "./GestioneTorneo.API/./GestioneTorneo.API.csproj"
COPY . .
WORKDIR "/src/GestioneTorneo.API"
RUN dotnet build "./GestioneTorneo.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GestioneTorneo.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GestioneTorneo.API.dll"]

