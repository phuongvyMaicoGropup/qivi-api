FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base 
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["qivi-api/qivi-api.csproj", "qivi-api/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "qivi-api/qivi-api.csproj"

COPY . .
WORKDIR "qivi-api/"
RUN dotnet build "qivi-api.csproj" -c Release -o /app

FROM build as publish
RUN dotnet publish "qivi-api.csproj" -c Release -o /app


FROM base as final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "qivi-api.dll"]

CMD ASPNETCORE_URLS=http://*:$PORT dotnet qivi-api.dll

