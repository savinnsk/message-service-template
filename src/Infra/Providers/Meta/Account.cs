using System.Net.Http.Headers;
using System.Net.Http.Json;
using Domain.Dtos.MetaApi;
using Domain.Records;
using Microsoft.Extensions.Logging;

namespace Infra.Providers.Meta;

public class Account(HttpClient httpClient,ILogger<Account> logger)
{
    //REGISTER
    public async Task<Result<string>> RegisterPhone(string metaToken, RegisterPhoneNumberDto data,MetaOptions options)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"https://graph.facebook.com/{options.Version}/{options.NumberId}/register");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", metaToken);
        request.Content = JsonContent.Create(data);
        
        logger.LogInformation("Meta Send Registration Phone NumberId: {NumberId}", options.NumberId);
        
        try
        {
            var result = await httpClient.SendAsync(request);

            var body = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode)
            {
                logger.LogWarning("Meta Register Number failed status {StatusCode}, NumberId {NumberId}, Body: {Body}",
                    result.StatusCode, options.NumberId, body);
            }

            return new Result<string>(
                Success: result.IsSuccessStatusCode,
                Data: body,
                Error: result.IsSuccessStatusCode ? null : body,
                StatusCode: (int)result.StatusCode
            );

        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Meta Register Phone error NumberId: {NumberId}", options.NumberId);
            throw;
        }
    }
    
    public async Task<Result<string>> DeregisterPhone(string metaToken, MetaOptions options)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"https://graph.facebook.com/{options.Version}/{options.NumberId}/deregister");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", metaToken);
        
        logger.LogInformation("Meta Send Deregister Phone NumberId: {NumberId}", options.NumberId);
        
        try
        {
            var result = await httpClient.SendAsync(request);

            var body = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode)
            {
                logger.LogWarning("Meta Deregister Number failed status {StatusCode}, NumberId {NumberId}, Body: {Body}",
                    result.StatusCode, options.NumberId, body);
            }

            return new Result<string>(
                Success: result.IsSuccessStatusCode,
                Data: body,
                Error: result.IsSuccessStatusCode ? null : body,
                StatusCode: (int)result.StatusCode
            );

        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Meta Deregister Phone error NumberId: {NumberId}", options.NumberId);
            throw;
        }
    }
    
    //WABA
    public async Task<Result<string>> SubscribeWABA(string metaToken, string WABAId, string version)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"https://graph.facebook.com/{version}/{WABAId}/subscribed_apps");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", metaToken);
        
        logger.LogInformation("Meta Subscribe WABA WABAId: {WABAId}", WABAId);
        
        try
        {
            var result = await httpClient.SendAsync(request);

            var body = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode)
            {
                logger.LogWarning("Meta Subscribe WABA failed status {StatusCode}, WABAId {WABAId}, Body: {Body}",
                    result.StatusCode, WABAId, body);
            }

            return new Result<string>(
                Success: result.IsSuccessStatusCode,
                Data: body,
                Error: result.IsSuccessStatusCode ? null : body,
                StatusCode: (int)result.StatusCode
            );

        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Meta Subscribe WABA error WABA Id: {WABAid}", WABAId);
            throw;
        }
    }
    
    public async Task<Result<string>> GetOwnedWABAs(string metaToken, string businessId, string version)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://graph.facebook.com/{version}/{businessId}/owned_whatsapp_business_accounts");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", metaToken);
        
        logger.LogInformation("Meta GetOwnedWABAs BusinessId: {BusinessId}", businessId);
        
        try
        {
            var result = await httpClient.SendAsync(request);

            var body = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode)
            {
                logger.LogWarning("Meta GetOwnedWABAs failed status {StatusCode}, BusinessId {BusinessId}, Body: {Body}",
                    result.StatusCode, businessId, body);
            }

            return new Result<string>(
                Success: result.IsSuccessStatusCode,
                Data: body,
                Error: result.IsSuccessStatusCode ? null : body,
                StatusCode: (int)result.StatusCode
            );

        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Meta GetOwnedWABAs error BusinessId: {BusinessId}", businessId);
            throw;
        }
    }

    public async Task<Result<string>> GetSharedWABAs(string metaToken, string businessId, string version)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://graph.facebook.com/{version}/{businessId}/client_whatsapp_business_accounts");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", metaToken);
        
        logger.LogInformation("Meta GetSharedWABAs BusinessId: {BusinessId}", businessId);
        
        try
        {
            var result = await httpClient.SendAsync(request);

            var body = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode)
            {
                logger.LogWarning("Meta GetSharedWABAs failed status {StatusCode}, BusinessId {BusinessId}, Body: {Body}",
                    result.StatusCode, businessId, body);
            }

            return new Result<string>(
                Success: result.IsSuccessStatusCode,
                Data: body,
                Error: result.IsSuccessStatusCode ? null : body,
                StatusCode: (int)result.StatusCode
            );

        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Meta GetSharedWABAs error BusinessId: {BusinessId}", businessId);
            throw;
        }
    }

    public async Task<Result<string>> GetPhonesByWABAId(string metaToken, string WABAId, string version)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://graph.facebook.com/{version}/{WABAId}/phone_numbers");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", metaToken);
        
        logger.LogInformation("Meta Get Phone ID WABAId {WABAId}", WABAId);
        
        try
        {
            var result = await httpClient.SendAsync(request);

            var body = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode)
            {
                logger.LogWarning("Meta Get Phone ID failed status {StatusCode}, WABAId {WABAId}",
                    result.StatusCode, WABAId);
            }

            return new Result<string>(
                Success: result.IsSuccessStatusCode,
                Data: body,
                Error: result.IsSuccessStatusCode ? null : body,
                StatusCode: (int)result.StatusCode
            );

        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Meta Get Phone ID error WABA Id: {WABAid}", WABAId);
            throw;
        }
    }
    
    //VERIFICATION CODE
    public async Task<Result<string>> RequestVerificationCode(string metaToken, RequestVerificationCodeDto data,MetaOptions options)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://graph.facebook.com/{options.Version}/{options.NumberId}/request_code");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", metaToken);
        request.Content = JsonContent.Create(data);
        
        logger.LogInformation("Meta Request Verification PhoneNumberId : {phoneNumberId}", options.NumberId);
        
        try
        {
            var result = await httpClient.SendAsync(request);

            var body = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode)
            {
                logger.LogWarning("Meta Request Verification failed status {StatusCode},PhoneNumberId : {phoneNumberId}",
                    result.StatusCode, options.NumberId);
            }

            return new Result<string>(
                Success: result.IsSuccessStatusCode,
                Data: body,
                Error: result.IsSuccessStatusCode ? null : body,
                StatusCode: (int)result.StatusCode
            );

        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Meta Request Verification error PhoneNumberId : {phoneNumberId}", options.NumberId);
            throw;
        }
    }
    
    public async Task<Result<string>> VerifyCode(string metaToken, VerifyCodeDto data,MetaOptions options)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://graph.facebook.com/{options.Version}/{options.NumberId}/verify_code");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", metaToken);
        request.Content = JsonContent.Create(data);
        
        logger.LogInformation("Meta VerifyCode PhoneNumberId : {phoneNumberId}", options.NumberId);
        
        try
        {
            var result = await httpClient.SendAsync(request);

            var body = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode)
            {
                logger.LogWarning("Meta VerifyCode failed status {StatusCode},PhoneNumberId : {phoneNumberId}",
                    result.StatusCode, options.NumberId);
            }

            return new Result<string>(
                Success: result.IsSuccessStatusCode,
                Data: body,
                Error: result.IsSuccessStatusCode ? null : body,
                StatusCode: (int)result.StatusCode
            );

        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Meta VerifyCode error PhoneNumberId : {phoneNumberId}", options.NumberId);
            throw;
        }
    }
    
    public async Task<Result<string>> SetTwoStepVerification(string metaToken, SetTwoTepVerificationCodeDto data,MetaOptions options)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://graph.facebook.com/{options.Version}/{options.NumberId}");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", metaToken);
        request.Content = JsonContent.Create(data);
        
        logger.LogInformation("Meta SetTwoStepVerification PhoneNumberId : {phoneNumberId}", options.NumberId);
        
        try
        {
            var result = await httpClient.SendAsync(request);

            var body = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode)
            {
                logger.LogWarning("Meta SetTwoStepVerification failed status {StatusCode},PhoneNumberId : {phoneNumberId}",
                    result.StatusCode, options.NumberId);
            }

            return new Result<string>(
                Success: result.IsSuccessStatusCode,
                Data: body,
                Error: result.IsSuccessStatusCode ? null : body,
                StatusCode: (int)result.StatusCode
            );

        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Meta SetTwoStepVerification error PhoneNumberId : {phoneNumberId}", options.NumberId);
            throw;
        }
    }

}
