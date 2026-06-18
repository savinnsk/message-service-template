using System.Net.Http;

namespace message_service.Infra.EvolutionGo;

public class EvolutionGoIntegration
{
    private readonly HttpClient _httpClient;

    public EvolutionGoIntegration(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public void CreateInstance(string instanceName)
    {
        _httpClient.PostAsJsonAsync("/instance/create",new
        {
            name = instanceName,
            advanceSettings = new
            {
                alwaysOnline = true,
                ignoreGroups = true,
                ignoreStatus = true,
                readMessages = true,
                rejectCall = true
            }
        });
    }

}