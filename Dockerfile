#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CryptoApp/CryptoApp.csproj", "CryptoApp/"]
COPY ["CryptoApp.Commons/CryptoApp.Commons.csproj", "CryptoApp.Commons/"]
COPY ["CryptoApp.Data/CryptoApp.Data.csproj", "CryptoApp.Data/"]
COPY ["CryptoApp.Models/CryptoApp.Models.csproj", "CryptoApp.Models/"]
COPY ["CryptoApp.Services/CryptoApp.Services.csproj", "CryptoApp.Services/"]


RUN dotnet restore "CryptoApp/CryptoApp.csproj"
WORKDIR "/src/CryptoApp"
COPY . .
RUN dotnet build "CryptoApp/CryptoApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CryptoApp/CryptoApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet CryptoApp.dll