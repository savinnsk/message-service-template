using message_service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<InstanceService>();
        
        return services;
    }

}