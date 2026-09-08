using Microsoft.Extensions.DependencyInjection;
using Services.EvolutionGo;
using Services.EvolutionGo.Instance;

namespace Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<InstanceService>();
        services.AddScoped<MessageService>();
        services.AddScoped<MetaApi.MessageService>();
        return services;
    }

}