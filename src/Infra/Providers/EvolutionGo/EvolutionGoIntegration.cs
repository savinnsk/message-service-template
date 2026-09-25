using System.Net.Http.Json;
using Domain.Dtos;
using Domain.Records;

namespace Infra.Providers.EvolutionGo;

public class EvolutionGoIntegration(HttpClient httpClient)
{

    //INSTANCE
    public async Task<Result<string>> CreateInstance(string evoGoToken, CreateInstanceDto data)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "/instance/create");
        request.Headers.Add("apikey", evoGoToken);
        request.Content = JsonContent.Create(data);
        
        var result = await httpClient.SendAsync(request);
        
        var body = await result.Content.ReadAsStringAsync();
        
        return new Result<string>(
            Success: result.IsSuccessStatusCode,
            Data: body,
            Error: result.IsSuccessStatusCode ? null : body,
            StatusCode: (int)result.StatusCode
            );
    }
    
    public async Task<Result<string>> Delete(string evoGoToken, string instanceId)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, $"/instance/delete/{instanceId}");
        request.Headers.Add("apikey", evoGoToken);
        
        var result = await httpClient.SendAsync(request);
        
        var body = await result.Content.ReadAsStringAsync();
        
        return new Result<string>(
            Success: result.IsSuccessStatusCode,
            Data: body,
            Error: result.IsSuccessStatusCode ? null : body,
            StatusCode: (int)result.StatusCode
        );
    }

    public async Task<Result<string>> GetAll(string evoGoToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/instance/all");
        request.Headers.Add("apikey", evoGoToken);
        
        var result = await httpClient.SendAsync(request);
        
        var body = await result.Content.ReadAsStringAsync();
        
        return new Result<string>(
            Success: result.IsSuccessStatusCode,
            Data: body,
            Error: result.IsSuccessStatusCode ? null : body,
            StatusCode: (int)result.StatusCode
        );
    }
    
    public async Task<Result<string>> Get(string evoGoToken, string instanceId)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"/instance/info/{instanceId}");
        request.Headers.Add("apikey", evoGoToken);
        
        var result = await httpClient.SendAsync(request);
        
        var body = await result.Content.ReadAsStringAsync();
        
        return new Result<string>(
            Success: result.IsSuccessStatusCode,
            Data: body,
            Error: result.IsSuccessStatusCode ? null : body,
            StatusCode: (int)result.StatusCode
        );
    }
    public async Task<Result<string>> ConnectQr(string evoGoToken)
    {

        var request = new HttpRequestMessage(HttpMethod.Get, "/instance/qr");
        request.Headers.Add("apikey", evoGoToken);
        
        var result = await httpClient.SendAsync(request);
        
        var body = await result.Content.ReadAsStringAsync();
        
        return new Result<string>(
            Success: result.IsSuccessStatusCode,
            Data: body,
            Error: result.IsSuccessStatusCode ? null : body,
            StatusCode: (int)result.StatusCode
        );
    }
    
    public async Task<Result<string>> GetStatus(string evoGoToken)
    {

        var request = new HttpRequestMessage(HttpMethod.Get, "/instance/status");
        request.Headers.Add("apikey", evoGoToken);
        
        var result = await httpClient.SendAsync(request);
        
        var body = await result.Content.ReadAsStringAsync();
        
        return new Result<string>(
            Success: result.IsSuccessStatusCode,
            Data: body,
            Error: result.IsSuccessStatusCode ? null : body,
            StatusCode: (int)result.StatusCode
        );
    }
    
    public async Task<Result<string>> Disconnect(string evoGoToken)
    {
        
        var request = new HttpRequestMessage(HttpMethod.Post, "/instance/disconnect");
        request.Headers.Add("apikey", evoGoToken);

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
    public async Task<Result<string>> SendText(string evoGoToken,TextMessage msg)
    {
        
        var request = new HttpRequestMessage(HttpMethod.Post, "/send/text");
        request.Headers.Add("apikey",evoGoToken);
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
    
    public async Task<Result<string>> SendMedia(string evoGoToken,MediaMessage msg)
    {
        
        var request = new HttpRequestMessage(HttpMethod.Post, "/send/media");
        request.Headers.Add("apikey",evoGoToken);
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
    
    public async Task<Result<string>> SendLink(string evoGoToken,TextMessage msg)
    {
        
        var request = new HttpRequestMessage(HttpMethod.Post, "/send/link");
        request.Headers.Add("apikey",evoGoToken);
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
    
    public async Task<Result<string>> SendButton(string evoGoToken,ButtonMessage msg)
    {
        
        var request = new HttpRequestMessage(HttpMethod.Post, "/send/button");
        request.Headers.Add("apikey",evoGoToken);
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
    
    public async Task<Result<string>> SendList(string evoGoToken,ListMessage msg)
    {
        
        var request = new HttpRequestMessage(HttpMethod.Post, "/send/list");
        request.Headers.Add("apikey",evoGoToken);
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
