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
COPY ["GestioneGioco.API/GestioneGioco.API.csproj", "GestioneGioco.API/"]
COPY ["GestioneGioco.Business/GestioneGioco.Business.csproj", "GestioneGioco.Business/"]
COPY ["GestioneGioco.Repository/GestioneGioco.Repository.csproj", "GestioneGioco.Repository/"]
COPY ["GestioneGioco.Shared/GestioneGioco.Shared.csproj", "GestioneGioco.Shared/"]
RUN dotnet restore "./GestioneGioco.API/./GestioneGioco.API.csproj"
COPY . .
WORKDIR "/src/GestioneGioco.API"
RUN dotnet build "./GestioneGioco.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GestioneGioco.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GestioneGioco.API.dll"]

