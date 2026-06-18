using Microsoft.Extensions.Configuration;

namespace message_service.Infra.Evolution;

public class EvolutionGoIntegration
{
    public HttpClient _httpClient;
    public IConfiguration _configuration;

    public EvolutionGoIntegration(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
    
    

}