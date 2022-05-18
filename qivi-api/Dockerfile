#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Core/Core.csproj", "Core/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["qivi-api/qivi-api.csproj", "qivi-api/"]
RUN dotnet restore "qivi-api/qivi-api.csproj"
COPY . .
WORKDIR "/src/qivi-api"
RUN dotnet build "qivi-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "qivi-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "qivi-api.dll"]
