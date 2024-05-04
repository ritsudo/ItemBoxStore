#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /migrator-app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /migrator-src

COPY ["src/Application/ItemBoxStore.Application/ItemBoxStore.Application.csproj", "Application/ItemBoxStore.Application/"]
COPY ["src/Contracts/ItemBoxStore.Contracts/ItemBoxStore.Contracts.csproj", "Contracts/ItemBoxStore.Contracts/"]
COPY ["src/Domain/ItemBoxStore.Domain/ItemBoxStore.Domain.csproj", "Domain/ItemBoxStore.Domain/"]
COPY ["src/Infrastructure/ItemBoxStore.Infrastructure/ItemBoxStore.Infrastructure.csproj", "Infrastructure/ItemBoxStore.Infrastructure/"]
COPY ["src/DbMigrator/ItemBoxStore.DbMigrator.csproj", "DbMigrator/"]

RUN dotnet restore --disable-parallel "./DbMigrator/ItemBoxStore.DbMigrator.csproj"
COPY ./src/ .
WORKDIR "/migrator-src/DbMigrator"
RUN dotnet build "./ItemBoxStore.DbMigrator.csproj" -c $BUILD_CONFIGURATION -o /migrator-app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR "/migrator-src/DbMigrator"
RUN dotnet publish "./ItemBoxStore.DbMigrator.csproj" -c $BUILD_CONFIGURATION -o /migrator-app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /migrator-app
COPY --from=publish /migrator-app/publish .
ENTRYPOINT ["dotnet", "ItemBoxStore.DbMigrator.dll"]