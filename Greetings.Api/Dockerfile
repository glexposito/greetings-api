FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Greetings.Api/Greetings.Api.csproj", "Greetings.Api/"]
RUN dotnet restore "Greetings.Api/Greetings.Api.csproj"
COPY . .
WORKDIR "/src/Greetings.Api"
RUN dotnet build "./Greetings.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Greetings.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Greetings.Api.dll"]

# Podman requires mounting the volume with something like:
#   -v <host-output-folder>:/app/bin/Debug/net9.0
# to avoid SELinux permission issues when accessing runtime files.
# For example:
#   -v /home/guille/Dev/Greetings/Greetings.Api/bin/Debug/net9.0:/app/bin/Debug/net9.0