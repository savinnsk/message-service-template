using System.Net.Http.Headers;
using message_service.Infra.Evolution;
using message_service.Infra.EvolutionGo;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace message_service.Infra;

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
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", options.EvolutionGoToken);
        });
        
        
        return services;
        
    }
}