#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/Hosts/ItemBoxStore.API/ItemBoxStore.API.csproj", "Hosts/ItemBoxStore.API/"]
COPY ["src/Application/ItemBoxStore.Application/ItemBoxStore.Application.csproj", "Application/ItemBoxStore.Application/"]
COPY ["src/Contracts/ItemBoxStore.Contracts/ItemBoxStore.Contracts.csproj", "Contracts/ItemBoxStore.Contracts/"]
COPY ["src/Domain/ItemBoxStore.Domain/ItemBoxStore.Domain.csproj", "Domain/ItemBoxStore.Domain/"]
COPY ["src/Infrastructure/ItemBoxStore.Infrastructure/ItemBoxStore.Infrastructure.csproj", "Infrastructure/ItemBoxStore.Infrastructure/"]
COPY ["src/DbMigrator/ItemBoxStore.DbMigrator.csproj", "DbMigrator/DbMigrator/"]
COPY ["src/Tests/Academy.ItemBoxStore.UnitTests/Academy.ItemBoxStore.UnitTests.csproj", "Tests/Academy.ItemBoxStore.UnitTests/"]

RUN dotnet restore "./Hosts/ItemBoxStore.API/ItemBoxStore.API.csproj"
COPY ./src/ .
WORKDIR "/src/Hosts/ItemBoxStore.API"
RUN dotnet build "./ItemBoxStore.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR "/src/Hosts/ItemBoxStore.API"
RUN dotnet publish "./ItemBoxStore.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY "src/Hosts/ItemBoxStore.API/Assets/Tahoma.ttf" "/app/Assets/Tahoma.ttf"
COPY "src/Hosts/ItemBoxStore.API/Assets/libSkiaSharp.so" "/app/libSkiaSharp.so"
COPY "src/Hosts/ItemBoxStore.API/Assets/libHarfBuzzSharp.so" "/app/libHarfBuzzSharp.so"
ENTRYPOINT ["dotnet", "ItemBoxStore.API.dll"]