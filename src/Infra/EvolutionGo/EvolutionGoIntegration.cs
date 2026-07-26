using System.Net.Http.Json;
using System.Text.Json;
using Domain.Dtos;
using Domain.Records;

namespace message_service.Infra.EvolutionGo;

public class EvolutionGoIntegration(HttpClient httpClient)
{

    public async Task<Result<string>> CreateInstance(CreateInstanceDto data)
    {
        
       var result = await httpClient.PostAsJsonAsync("/instance/create", data);
        
        var body = await result.Content.ReadAsStringAsync();
        
        return new Result<string>(
            Success: result.IsSuccessStatusCode,
            Data: body,
            Error: result.IsSuccessStatusCode ? null : body,
            StatusCode: (int)result.StatusCode
            );
    }
    
    public async Task<Result<string>> ConnectQr(string instanceName)
    {

        var request = new HttpRequestMessage(HttpMethod.Get, "/instance/qr");
        request.Headers.Remove("apikey");
        request.Headers.Add("apikey", instanceName);
        
        var result = await httpClient.SendAsync(request);
        
        var body = await result.Content.ReadAsStringAsync();
        
        return new Result<string>(
            Success: result.IsSuccessStatusCode,
            Data: body,
            Error: result.IsSuccessStatusCode ? null : body,
            StatusCode: (int)result.StatusCode
        );
    }
    
    public async Task<Result<string>> GetStatus(string instanceName)
    {

        var request = new HttpRequestMessage(HttpMethod.Get, "/instance/status");
        request.Headers.Remove("apikey");
        request.Headers.Add("apikey", instanceName);
        
        var result = await httpClient.SendAsync(request);
        
        var body = await result.Content.ReadAsStringAsync();
        
        return new Result<string>(
            Success: result.IsSuccessStatusCode,
            Data: body,
            Error: result.IsSuccessStatusCode ? null : body,
            StatusCode: (int)result.StatusCode
        );
    }
    
    public async Task<Result<string>> Delete(string instanceId)
    {
        
        var result = await httpClient.DeleteAsync($"/instance/delete/{instanceId}");
        
        var body = await result.Content.ReadAsStringAsync();
        
        return new Result<string>(
            Success: result.IsSuccessStatusCode,
            Data: body,
            Error: result.IsSuccessStatusCode ? null : body,
            StatusCode: (int)result.StatusCode
        );
    }

}