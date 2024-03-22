FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["HackatonFiap.sln", "HackatonFiap.sln"]
COPY ["HackatonFiap.Aplicacao/HackatonFiap.Aplicacao.csproj", "HackatonFiap.Aplicacao/"]
COPY ["HackatonFiap.Comum/HackatonFiap.Comum.csproj", "HackatonFiap.Comum/"]
COPY ["HackatonFiap.Domain/HackatonFiap.Domain.csproj", "HackatonFiap.Domain/"]
COPY ["HackatonFiap.Infraestrutura/HackatonFiap.Infraestrutura.csproj", "HackatonFiap.Infraestrutura/"]
COPY ["HackatonFiap.WebApi/HackatonFiap.WebApi.csproj", "HackatonFiap.WebApi/"]
RUN dotnet restore "./HackatonFiap.sln"

COPY . .
WORKDIR "/src/HackatonFiap.WebApi"
RUN dotnet build "./HackatonFiap.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HackatonFiap.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HackatonFiap.dll"]