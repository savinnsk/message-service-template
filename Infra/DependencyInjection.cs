using System.Net.Http.Headers;
using message_service.Infra.Evolution;
using message_service.Infra.EvolutionGo;
using Microsoft.Extensions.Options;

namespace message_service.Infra;

public static class DependencyInjection
{
    public static void AddInfraServices(this IHostApplicationBuilder builder)
    {
        builder.Services.Configure<EvolutionOptions>(
            builder.Configuration.GetSection("EvolutionGo")
            );
            
        builder.Services.AddHttpClient<EvolutionGoIntegration>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<EvolutionOptions>>().Value;
            
            client.BaseAddress = new Uri(options.EvolutionGoUri);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", options.EvolutionGoToken);
        });
        
    }
}