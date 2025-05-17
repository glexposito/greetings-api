using OpenTelemetry.Exporter;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;


var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = AppContext.BaseDirectory
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// ReSharper disable once IdentifierTypo
var otelConfig = builder.Configuration.GetSection("OpenTelemetry:NewRelic");
var apiKey = otelConfig["ApiKey"];
var endpoint = otelConfig["Endpoint"];

Action<OtlpExporterOptions> exporter = opt =>
{
    opt.Endpoint = new Uri(endpoint!);
    opt.Protocol = OtlpExportProtocol.Grpc;
    // ReSharper disable once StringLiteralTypo
    // API key should be in a secure vault (Azure Key Vault – not in free tier :p) but this is fine for a PoC.
    opt.Headers = $"api-key={apiKey}";
};

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => {
        tracing
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("Greetings"))
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddConsoleExporter()
            .AddOtlpExporter(exporter);
    })
    .WithMetrics(metrics => {
        metrics
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("Greetings"))
            .AddRuntimeInstrumentation()
            .AddHttpClientInstrumentation()
            .AddAspNetCoreInstrumentation()
            .AddConsoleExporter()
            .AddOtlpExporter(exporter);
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public abstract partial class Program;