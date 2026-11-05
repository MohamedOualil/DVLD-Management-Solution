# syntax=docker/dockerfile:1

# Stage 1: build the API and its libraries.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files first for cached package restoration.
COPY backend/DVLD.Domain/DVLD.Domain.csproj backend/DVLD.Domain/
COPY backend/DVLD.Application/DVLD.Application.csproj backend/DVLD.Application/
COPY backend/DVLD.Infrastructure/DVLD.Infrastructure.csproj backend/DVLD.Infrastructure/
COPY shared/DVLD.Contracts/DVLD.Contracts.csproj shared/DVLD.Contracts/
COPY backend/DVLD.Api/DVLD.Api.csproj backend/DVLD.Api/

# Restore packages for the API and all referenced libraries.
RUN dotnet restore backend/DVLD.Api/DVLD.Api.csproj

# Copy backend and shared library source code.
COPY backend/ backend/
COPY shared/ shared/

# Publish the API, including its required library DLLs.
RUN dotnet publish backend/DVLD.Api/DVLD.Api.csproj \
    -c Release \
    -o /app/publish \
    --no-restore \
    /p:UseAppHost=false

# Stage 2: run the published application.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080

USER app

ENTRYPOINT ["dotnet", "DVLD.Api.dll"]