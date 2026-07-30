using message_service.Services;
using Microsoft.Extensions.DependencyInjection;
using Services.MessageWhatsapp;

namespace Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<InstanceService>();
        services.AddScoped<MessageWhatsappService>();
        
        return services;
    }

}