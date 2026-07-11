using System.Net.Http.Json;
using Domain.Dtos;
using Domain.Records;

namespace message_service.Infra.EvolutionGo;

public class EvolutionGoIntegration(HttpClient httpClient)
{

    public async Task<Result<string>> CreateInstance(CreateInstanceDto data)
    {
        
        var request = new CreateInstanceDto(
            Name: data.Name,
            Token: Guid.NewGuid().ToString(), 
            AdvanceSettings: new AdvanceSettings());
        
        
       var result = await httpClient.PostAsJsonAsync("/instance/create", request);
        
        var body = await result.Content.ReadAsStringAsync();
        
        return new Result<string>(
            Success: result.IsSuccessStatusCode,
            Data: body,
            Error: result.IsSuccessStatusCode ? null : body,
            StatusCode: (int)result.StatusCode
            );
    }

}