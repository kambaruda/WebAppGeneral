using Core.Services.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Core.Services.Service.DependancyInjection;

public static class AddGenericServiceExtensions
{
    public static IServiceCollection AddGenericService(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<ServiceOptions>(
            configuration.GetSection(ServiceOptions.SectionName));

        services.AddScoped(sp =>
            sp.GetRequiredService<IOptions<ServiceOptions>>().Value);

        services.AddScoped<IServiceRepository, ServiceClient>();

        return services;
    }
}
