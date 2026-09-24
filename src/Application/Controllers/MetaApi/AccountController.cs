using System.Text.Json.Serialization;
using Domain.Dtos.MetaApi;
using Microsoft.AspNetCore.Mvc;
using Services.Providers.MetaApi;

namespace Application.Controllers.MetaApi;

public record MetaAccountRequest<TData>(
    [property: JsonPropertyName("options")] MetaOptions Options,
    [property: JsonPropertyName("data")] TData Data
);

public record MetaAccountOptionsRequest(
    [property: JsonPropertyName("options")] MetaOptions Options
);

[ApiController]
[Route("api/meta/account")]
public class AccountController(AccountService accountService) : ControllerBase
{
    [HttpPost("phone/register")]
    public async Task<IActionResult> RegisterPhone([FromBody] MetaAccountRequest<RegisterPhoneNumberDto> request)
    {
        var result = await accountService.RegisterPhone(request.Data, request.Options);

        return HttpResult.From(result);
    }

    [HttpPost("phone/deregister")]
    public async Task<IActionResult> DeregisterPhone([FromBody] MetaAccountOptionsRequest request)
    {
        var result = await accountService.DeregisterPhone(request.Options);

        return HttpResult.From(result);
    }

    [HttpPost("waba/{wabaId}/subscribe")]
    public async Task<IActionResult> SubscribeWABA(string wabaId, [FromBody] MetaAccountOptionsRequest request)
    {
        var result = await accountService.SubscribeWABA(wabaId, request.Options);

        return HttpResult.From(result);
    }

    [HttpPost("business/{businessId}/owned-wabas")]
    public async Task<IActionResult> GetOwnedWABAs(string businessId, [FromBody] MetaAccountOptionsRequest request)
    {
        var result = await accountService.GetOwnedWABAs(businessId, request.Options);

        return HttpResult.From(result);
    }

    [HttpPost("business/{businessId}/shared-wabas")]
    public async Task<IActionResult> GetSharedWABAs(string businessId, [FromBody] MetaAccountOptionsRequest request)
    {
        var result = await accountService.GetSharedWABAs(businessId, request.Options);

        return HttpResult.From(result);
    }

    [HttpPost("waba/{wabaId}/phones")]
    public async Task<IActionResult> GetPhonesByWABAId(string wabaId, [FromBody] MetaAccountOptionsRequest request)
    {
        var result = await accountService.GetPhonesByWABAId(wabaId, request.Options);

        return HttpResult.From(result);
    }

    [HttpPost("phone/request-code")]
    public async Task<IActionResult> RequestVerificationCode([FromBody] MetaAccountRequest<RequestVerificationCodeDto> request)
    {
        var result = await accountService.RequestVerificationCode(request.Data, request.Options);

        return HttpResult.From(result);
    }

    [HttpPost("phone/verify-code")]
    public async Task<IActionResult> VerifyCode([FromBody] MetaAccountRequest<VerifyCodeDto> request)
    {
        var result = await accountService.VerifyCode(request.Data, request.Options);

        return HttpResult.From(result);
    }

    [HttpPost("phone/two-step-verification")]
    public async Task<IActionResult> SetTwoStepVerification([FromBody] MetaAccountRequest<SetTwoTepVerificationCodeDto> request)
    {
        var result = await accountService.SetTwoStepVerification(request.Data, request.Options);

        return HttpResult.From(result);
    }
}
