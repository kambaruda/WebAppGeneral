
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Core.DependancyInjection;

public static class SerilogExtensions
{
    public static IHostBuilder AddSerilog(
        this IHostBuilder host,
        IConfiguration configuration)
    {
        return host.UseSerilog((context, services, logger) =>
        {
            logger
                .ReadFrom.Configuration(configuration)
                .ReadFrom.Services(services)
                .Enrich.FromLogContext();
        });
    }
}
