using Infra.EvolutionGo;
using Infra.Providers.EvolutionGo;
using Infra.Providers.Meta;
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

        services.AddHttpClient<EvolutionGoIntegration>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<EvolutionOptions>>().Value;
            
            client.BaseAddress = new Uri(options.EvolutionGoUri);
        });
        
        services.AddHttpClient<MetaApiMessage>();

        services.AddHttpClient<Account>();
        
        return services;
        
    }
}
