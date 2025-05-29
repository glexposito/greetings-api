FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["Greetings.FunctionWorker/Greetings.FunctionWorker.csproj", "Greetings.FunctionWorker/"]
RUN dotnet restore "Greetings.FunctionWorker/Greetings.FunctionWorker.csproj"
COPY . .
WORKDIR "/src/Greetings.FunctionWorker"
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/azure-functions/dotnet-isolated:4-dotnet-isolated9.0
WORKDIR /home/site/wwwroot
COPY --from=build /app/publish .
