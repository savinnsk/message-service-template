using System.Net.Http.Json;
using Domain.Dtos;
using Domain.Records;

namespace Infra.EvolutionGo;

public class EvolutionGoIntegration(HttpClient httpClient)
{

    //INSTANCE
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

    public async Task<Result<string>> GetAll()
    {
        
        var result = await httpClient.GetAsync("/instance/all");
        
        var body = await result.Content.ReadAsStringAsync();
        
        return new Result<string>(
            Success: result.IsSuccessStatusCode,
            Data: body,
            Error: result.IsSuccessStatusCode ? null : body,
            StatusCode: (int)result.StatusCode
        );
    }
    
    public async Task<Result<string>> Get(string instanceId)
    {
        
        var result = await httpClient.GetAsync($"/instance/info/{instanceId}");
        
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
    
    public async Task<Result<string>> Disconnect(string instanceToken)
    {
        
        var request = new HttpRequestMessage(HttpMethod.Post, "/instance/disconnect");
        request.Headers.Remove("apikey");
        request.Headers.Add("apikey", instanceToken);

        var result = await httpClient.SendAsync(request);
        
        var body = await result.Content.ReadAsStringAsync();
        
        return new Result<string>(
            Success: result.IsSuccessStatusCode,
            Data: body,
            Error: result.IsSuccessStatusCode ? null : body,
            StatusCode: (int)result.StatusCode
        );
    }

    
    //MESSAGE
    public async Task<Result<string>> SendText(string tokenInstance,TextMessage msg)
    {
        
        var request = new HttpRequestMessage(HttpMethod.Post, "/send/text");
        request.Headers.Remove("apikey");
        request.Headers.Add("apikey",tokenInstance);
        request.Content = JsonContent.Create(msg);
        
        var result = await httpClient.SendAsync(request);
        
        var body = await result.Content.ReadAsStringAsync();
        
        return new Result<string>(
            Success: result.IsSuccessStatusCode,
            Data: body,
            Error: result.IsSuccessStatusCode ? null : body,
            StatusCode: (int)result.StatusCode
        );
    }
    
    public async Task<Result<string>> SendMedia(string tokenInstance,MediaMessage msg)
    {
        
        var request = new HttpRequestMessage(HttpMethod.Post, "/send/media");
        request.Headers.Remove("apikey");
        request.Headers.Add("apikey",tokenInstance);
        request.Content = JsonContent.Create(msg);
        
        var result = await httpClient.SendAsync(request);
        
        var body = await result.Content.ReadAsStringAsync();
        
        return new Result<string>(
            Success: result.IsSuccessStatusCode,
            Data: body,
            Error: result.IsSuccessStatusCode ? null : body,
            StatusCode: (int)result.StatusCode
        );
    }
    
    public async Task<Result<string>> SendLink(string tokenInstance,TextMessage msg)
    {
        
        var request = new HttpRequestMessage(HttpMethod.Post, "/send/link");
        request.Headers.Remove("apikey");
        request.Headers.Add("apikey",tokenInstance);
        request.Content = JsonContent.Create(msg);
        
        var result = await httpClient.SendAsync(request);
        
        var body = await result.Content.ReadAsStringAsync();
        
        return new Result<string>(
            Success: result.IsSuccessStatusCode,
            Data: body,
            Error: result.IsSuccessStatusCode ? null : body,
            StatusCode: (int)result.StatusCode
        );
    }
    
    public async Task<Result<string>> SendButton(string tokenInstance,ButtonMessage msg)
    {
        
        var request = new HttpRequestMessage(HttpMethod.Post, "/send/button");
        request.Headers.Remove("apikey");
        request.Headers.Add("apikey",tokenInstance);
        request.Content = JsonContent.Create(msg);
        
        var result = await httpClient.SendAsync(request);
        
        var body = await result.Content.ReadAsStringAsync();
        
        return new Result<string>(
            Success: result.IsSuccessStatusCode,
            Data: body,
            Error: result.IsSuccessStatusCode ? null : body,
            StatusCode: (int)result.StatusCode
        );
    }
    
    public async Task<Result<string>> SendList(string tokenInstance,ListMessage msg)
    {
        
        var request = new HttpRequestMessage(HttpMethod.Post, "/send/list");
        request.Headers.Remove("apikey");
        request.Headers.Add("apikey",tokenInstance);
        request.Content = JsonContent.Create(msg);
        
        var result = await httpClient.SendAsync(request);
        
        var body = await result.Content.ReadAsStringAsync();
        
        return new Result<string>(
            Success: result.IsSuccessStatusCode,
            Data: body,
            Error: result.IsSuccessStatusCode ? null : body,
            StatusCode: (int)result.StatusCode
        );
    }
}