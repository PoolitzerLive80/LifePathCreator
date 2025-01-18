# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app

# Expose HTTP port
EXPOSE 5080

# Expose HTTPS port
EXPOSE 5081

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS with-node
RUN apt-get update
RUN apt-get install curl
RUN curl -sL https://deb.nodesource.com/setup_20.x | bash
RUN apt-get -y install nodejs

FROM with-node AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LifePathBuilder.Server/LifePathBuilder.Server.csproj", "LifePathBuilder.Server/"]
COPY ["lifepathbuilder.client/lifepathbuilder.client.esproj", "lifepathbuilder.client/"]
RUN dotnet restore "./LifePathBuilder.Server/LifePathBuilder.Server.csproj"
COPY . . 
WORKDIR "/src/LifePathBuilder.Server"
RUN dotnet build "./LifePathBuilder.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LifePathBuilder.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LifePathBuilder.Server.dll"]
