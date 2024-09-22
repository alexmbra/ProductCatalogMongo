# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base


USER root
# Create the directory for the certificate in the container
RUN mkdir -p /https
COPY ProductApi/https/ProductCatalogMongo.pfx /https/ProductCatalogMongo.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="Numsey2024"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path="/https/ProductCatalogMongo.pfx"

# Set permissions for the certificate (you might need to adjust this based on your environment)
RUN chmod 644 /https/ProductCatalogMongo.pfx

USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8001


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProductApi/ProductApi.csproj", "ProductApi/"]
RUN dotnet restore "./ProductApi/ProductApi.csproj"
COPY . .
WORKDIR "/src/ProductApi"
RUN dotnet build "./ProductApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProductApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductApi.dll"]


