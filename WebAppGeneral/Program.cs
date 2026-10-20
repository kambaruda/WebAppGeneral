using Core.Services.Service.DependancyInjection;
using Core.DependancyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddGenericService(builder.Configuration);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Lifetime.ApplicationStarted.Register(() =>
{
    var endpoints = app.Services
        .GetRequiredService<EndpointDataSource>()
        .Endpoints;

    foreach (var endpoint in endpoints.OfType<RouteEndpoint>())
    {
        var methods = endpoint.Metadata
            .GetMetadata<HttpMethodMetadata>()?
            .HttpMethods ?? ["ANY"];

        app.Logger.LogInformation(
            "Endpoint: {Methods} /{Route}",
            string.Join(", ", methods),
            endpoint.RoutePattern.RawText);
    }
});

app.Run();
