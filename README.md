# Greetings

A minimal ASP.NET Core Web API that provides simple greeting endpoints and demonstrates OpenTelemetry integration.

This is a PoC for sending metrics and traces to New Relic using OpenTelemetry.

## Features

- REST API with endpoints for "Hello" and "Bye" greetings
- OpenAPI (Swagger) documentation
- OpenTelemetry tracing and metrics with New Relic exporter
- Docker support
- xUnit integration tests

## Endpoints

| Method | Route              | Description      |
|--------|--------------------|------------------|
| GET    | `/Greetings/hello` | Returns "Hello!" |
| GET    | `/Greetings/bye`   | Returns "Bye!"   |

## Running Locally

### Prerequisites

- .NET 9 SDK (https://dotnet.microsoft.com/download)
- Docker (https://www.docker.com/) (optional)

### Build and Run

dotnet build
dotnet run --project Greetings.Api

The API will be available at http://localhost:5050.

### API Documentation

OpenAPI/Swagger is available at /swagger when running in Development mode.

## Running Tests

dotnet test

## Docker

Build and run the API in Docker:

docker build -t greetings-api -f Greetings.Api/Dockerfile .
docker run -p 8080:8080 greetings-api

The API will be available at http://localhost:8080.

## Project Structure

- Greetings.Api/ - Main Web API project
- Greetings.Tests/ - xUnit test project

## Telemetry

OpenTelemetry is configured in Program.cs to export traces and metrics to New Relic. Update the API key and endpoint in appsettings.json as needed.

## New Relic Screenshots

Below are screenshots showing New Relic integration:

### Spans

![Spans](https://github.com/user-attachments/assets/19042d7c-aed4-4270-9261-9046627e221a)


### Transactions

![Transactions](https://github.com/user-attachments/assets/cf55329f-46f0-4883-b5f6-eecdad029816)