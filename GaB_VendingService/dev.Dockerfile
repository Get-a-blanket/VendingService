#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
RUN dotnet tool install --global dotnet-ef --version 8.*
ENV PATH="$PATH:/root/.dotnet/tools"
COPY ["GaB_VendingService/GaB_VendingService.csproj", "GaB_VendingService/"]
RUN dotnet restore "./GaB_VendingService/GaB_VendingService.csproj"
COPY . .
RUN dotnet ef migrations add docker-build --context GaB_VendingService.DbConnector.ApplicationContext --project ./GaB_VendingService
WORKDIR "/src/GaB_VendingService"
RUN dotnet build "./GaB_VendingService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
RUN dotnet publish "./GaB_VendingService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN dotnet dev-certs https
ENTRYPOINT ["dotnet", "GaB_VendingService.dll"]