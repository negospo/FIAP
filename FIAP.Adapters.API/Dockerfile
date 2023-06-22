#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FIAP.Ports.API/FIAP.Adapters.API.csproj", "FIAP.Ports.API/"]
COPY ["FIAP.Adapters.PostgreSQL/FIAP.Adapters.PostgreSQL.csproj", "FIAP.Adapters.PostgreSQL/"]
COPY ["FIAP.Modules.Domain/FIAP.Modules.Domain.csproj", "FIAP.Modules.Domain/"]
COPY ["FIAP.Modules.Application/FIAP.Modules.Application.csproj", "FIAP.Modules.Application/"]
RUN dotnet restore "FIAP.Ports.API/FIAP.Adapters.API.csproj"
COPY . .
WORKDIR "/src/FIAP.Ports.API"
RUN dotnet build "FIAP.Adapters.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FIAP.Adapters.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FIAP.Adapters.API.dll"]