using Infra.EvolutionGo;
using Infra.MetaApiWpp;
using message_service.Infra.EvolutionGo;
using message_service.Infra.MetaApiWpp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EvolutionOptions>(
            configuration.GetSection("EvolutionGo")
            );

        services.Configure<MetaApiWppOptions>(
            configuration.GetSection("MetaApi")
            );
        
        services.AddHttpClient<EvolutionGoIntegration>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<EvolutionOptions>>().Value;
            
            client.BaseAddress = new Uri(options.EvolutionGoUri);
            client.DefaultRequestHeaders.Add(
                "apikey", options.EvolutionGoToken);
        });
        
        services.AddHttpClient<MetaApiMessage>();
        
        return services;
        
    }
}