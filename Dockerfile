# Use the appropriate SDK for .NET 8.0
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY src/EFCoreApp/*.csproj ./EFCoreApp/
WORKDIR /app/EFCoreApp
RUN dotnet restore

# Copy everything else and build
COPY src/EFCoreApp/ ./
RUN dotnet publish --no-restore -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/EFCoreApp/out .

ENTRYPOINT ["dotnet", "EFCoreApp.dll"]
