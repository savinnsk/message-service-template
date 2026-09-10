using System.Net.Http.Json;
using Domain.Dtos.MetaApi;
using Domain.Records;
using Microsoft.Extensions.Logging;

namespace Infra.MetaApiWpp;

public class MetaApiMessage(HttpClient httpClient,ILogger<MetaApiMessage> logger)
{

    public async Task<Result<string>> SendText(MetaOptions options, TextMessage data)
    {
        var request = new HttpRequestMessage(HttpMethod.Post,
            $"https://graph.facebook.com/{options.Version}/{options.NumberId}/messages");

        logger.LogInformation("Meta SendText NumberId: {NumberId}, Type: {Type}, To:{To}", options.NumberId, data.Type,
            data.To);

        try
        {
            
            request.Content = JsonContent.Create(data);

            var result = await httpClient.SendAsync(request);

            var body = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode)
            {
                logger.LogWarning("Meta SendText failed status {StatusCode}, NumberId {NumberId}, Body: {Body}", result.StatusCode, options.NumberId,body);
            }

            return new Result<string>(
                Success: result.IsSuccessStatusCode,
                Data: body,
                Error: result.IsSuccessStatusCode ? null : body,
                StatusCode: (int)result.StatusCode
            );

        }
        catch(Exception ex)
        {
            logger.LogError(ex, "Meta SendText error NumberId: {NumberId}", options.NumberId);
            throw;
        }
    }

    
    public async Task<Result<string>> SendList(MetaOptions options, ListMessage data)
    {
        var request = new HttpRequestMessage(HttpMethod.Post,
            $"https://graph.facebook.com/{options.Version}/{options.NumberId}/messages");

        logger.LogInformation("Meta Send List NumberId: {NumberId}, Type: {Type}, To:{To}", options.NumberId, data.Type,
            data.To);

        try
        {
            
            request.Content = JsonContent.Create(data);

            var result = await httpClient.SendAsync(request);

            var body = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode)
            {
                logger.LogWarning("Meta SendText failed status {StatusCode}, NumberId {NumberId}, Body: {Body}", result.StatusCode, options.NumberId,body);
            }

            return new Result<string>(
                Success: result.IsSuccessStatusCode,
                Data: body,
                Error: result.IsSuccessStatusCode ? null : body,
                StatusCode: (int)result.StatusCode
            );

        }
        catch(Exception ex)
        {
            logger.LogError(ex, "Meta SendText error NumberId: {NumberId}", options.NumberId);
            throw;
        }
    }
}