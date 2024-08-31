FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY ./EFCoreApp.DataAccess/EFCoreApp.DataAccess.csproj ./EFCoreApp.DataAccess/EFCoreApp.DataAccess.csproj
COPY ./EFCoreApp.Domain/EFCoreApp.Domain.csproj ./EFCoreApp.Domain/SolaERP.Domain.csproj
COPY ./EFCoreApp/EFCoreApp.csproj ./EFCoreApp/EFCoreApp.csproj

RUN dotnet nuget locals all --clear

RUN dotnet restore "./EFCoreApp/EFCoreApp.csproj"

COPY . ./

ENV DOTNET_HOSTBUILDER__RELOADCONFIGONCHANGE=false

RUN dotnet publish -c Release -o output

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/output .
ENTRYPOINT ["dotnet", "EFCoreApp.dll"]


