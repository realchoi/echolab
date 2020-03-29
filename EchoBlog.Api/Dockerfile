#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["EchoBlog.Api/EchoBlog.Api.csproj", "EchoBlog.Api/"]
COPY ["EchoBlog.Infrastructures/EchoBlog.Infrastructures.csproj", "EchoBlog.Infrastructures/"]
COPY ["EchoBlog.Domain/EchoBlog.Domains.csproj", "EchoBlog.Domain/"]
COPY ["EchoBlog.Domain.Abstractions/EchoBlog.Domain.Abstractions.csproj", "EchoBlog.Domain.Abstractions/"]
COPY ["EchoBlog.Infrastructures.Core/EchoBlog.Infrastructures.Core.csproj", "EchoBlog.Infrastructures.Core/"]
RUN dotnet restore "EchoBlog.Api/EchoBlog.Api.csproj"
COPY . .
WORKDIR "/src/EchoBlog.Api"
RUN dotnet build "EchoBlog.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EchoBlog.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EchoBlog.Api.dll"]
