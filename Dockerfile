FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base 
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["qivi-api/qivi-api.csproj", "qivi-api/"]
COPY ["/Core/Core.csproj", "Core/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "qivi-api/qivi-api.csproj"

#Copy the csproj file and restore any dependencies (via nuget)
# COPY *.csproj ./
# RUN dotnet restore

#copy the projecct files and build our release 

COPY . .
WORKDIR "/src/qivi-api"
RUN dotnet build "qivi-api.csproj" -c Release -o /app

FROM build as publish
RUN dotnet publish "qivi-api.csproj" -c Release -o /app


FROM base as final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "qivi-api.dll"]










































# EXPOSE 80

# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# WORKDIR /src

# COPY ["src/qivi-api/qivi-api.csproj", "src/qivi-api/"]
# COPY ["src/Infrastructure/Infrastructure.csproj", "src/Infrastructure/"]
# COPY ["src/Core/Core.csproj", "src/Core/"]

# RUN dotnet restore "src/qivi-api/qivi-api.csproj"

# COPY . ./
# RUN dotnet build "qivi-api.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "qivi-api.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "qivi-api.dll"]