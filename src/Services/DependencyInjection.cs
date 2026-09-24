using Microsoft.Extensions.DependencyInjection;
using Services.Providers.EvolutionGo;

namespace Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<InstanceService>();
        services.AddScoped<MessageService>();
        services.AddScoped<Providers.MetaApi.MessageService>();
        services.AddScoped<Providers.MetaApi.AccountService>();
        return services;
    }

}
