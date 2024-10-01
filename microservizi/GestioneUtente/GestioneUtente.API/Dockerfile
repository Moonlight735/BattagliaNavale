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
COPY ["GestioneUtente.API/GestioneUtente.API.csproj", "GestioneUtente.API/"]
COPY ["GestioneUtente.Business/GestioneUtente.Business.csproj", "GestioneUtente.Business/"]
COPY ["GestioneUtente.Repository/GestioneUtente.Repository.csproj", "GestioneUtente.Repository/"]
COPY ["GestioneUtente.Shared/GestioneUtente.Shared.csproj", "GestioneUtente.Shared/"]
RUN dotnet restore "./GestioneUtente.API/./GestioneUtente.API.csproj"
COPY . .
WORKDIR "/src/GestioneUtente.API"
RUN dotnet build "./GestioneUtente.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GestioneUtente.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GestioneUtente.API.dll"]

