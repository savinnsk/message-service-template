using Domain.Dtos.MetaApi;
using Microsoft.AspNetCore.Mvc;
using Services.Providers.MetaApi;

namespace Application.Controllers.MetaApi;

[ApiController]
[Route("api/meta/account")]
public class AccountController(AccountService accountService) : ControllerBase
{
    [HttpPost("phone/{numberId}/register")]
    public async Task<IActionResult> RegisterPhone(
        string numberId,
        [FromHeader(Name = "x-meta-token")] string metaToken,
        [FromHeader(Name = "x-meta-version")] string version,
        [FromBody] RegisterPhoneNumberDto data)
    {
        var result = await accountService.RegisterPhone(metaToken, data, CreateOptions(numberId, version));

        return HttpResult.From(result);
    }

    [HttpPost("phone/{numberId}/deregister")]
    public async Task<IActionResult> DeregisterPhone(
        string numberId,
        [FromHeader(Name = "x-meta-token")] string metaToken,
        [FromHeader(Name = "x-meta-version")] string version)
    {
        var result = await accountService.DeregisterPhone(metaToken, CreateOptions(numberId, version));

        return HttpResult.From(result);
    }

    [HttpPost("waba/{wabaId}/subscribe")]
    public async Task<IActionResult> SubscribeWABA(
        string wabaId,
        [FromHeader(Name = "x-meta-token")] string metaToken,
        [FromHeader(Name = "x-meta-version")] string version)
    {
        var result = await accountService.SubscribeWABA(metaToken, wabaId, NormalizeVersion(version));

        return HttpResult.From(result);
    }

    [HttpGet("business/{businessId}/owned-wabas")]
    public async Task<IActionResult> GetOwnedWABAs(
        string businessId,
        [FromHeader(Name = "x-meta-token")] string metaToken,
        [FromHeader(Name = "x-meta-version")] string version)
    {
        var result = await accountService.GetOwnedWABAs(metaToken, businessId, NormalizeVersion(version));

        return HttpResult.From(result);
    }

    [HttpGet("business/{businessId}/shared-wabas")]
    public async Task<IActionResult> GetSharedWABAs(
        string businessId,
        [FromHeader(Name = "x-meta-token")] string metaToken,
        [FromHeader(Name = "x-meta-version")] string version)
    {
        var result = await accountService.GetSharedWABAs(metaToken, businessId, NormalizeVersion(version));

        return HttpResult.From(result);
    }

    [HttpGet("waba/{wabaId}/phones")]
    public async Task<IActionResult> GetPhonesByWABAId(
        string wabaId,
        [FromHeader(Name = "x-meta-token")] string metaToken,
        [FromHeader(Name = "x-meta-version")] string version)
    {
        var result = await accountService.GetPhonesByWABAId(metaToken, wabaId, NormalizeVersion(version));

        return HttpResult.From(result);
    }

    [HttpPost("phone/{numberId}/request-code")]
    public async Task<IActionResult> RequestVerificationCode(
        string numberId,
        [FromHeader(Name = "x-meta-token")] string metaToken,
        [FromHeader(Name = "x-meta-version")] string version,
        [FromBody] RequestVerificationCodeDto data)
    {
        var result = await accountService.RequestVerificationCode(metaToken, data, CreateOptions(numberId, version));

        return HttpResult.From(result);
    }

    [HttpPost("phone/{numberId}/verify-code")]
    public async Task<IActionResult> VerifyCode(
        string numberId,
        [FromHeader(Name = "x-meta-token")] string metaToken,
        [FromHeader(Name = "x-meta-version")] string version,
        [FromBody] VerifyCodeDto data)
    {
        var result = await accountService.VerifyCode(metaToken, data, CreateOptions(numberId, version));

        return HttpResult.From(result);
    }

    [HttpPost("phone/{numberId}/two-step-verification")]
    public async Task<IActionResult> SetTwoStepVerification(
        string numberId,
        [FromHeader(Name = "x-meta-token")] string metaToken,
        [FromHeader(Name = "x-meta-version")] string version,
        [FromBody] SetTwoTepVerificationCodeDto data)
    {
        var result = await accountService.SetTwoStepVerification(metaToken, data, CreateOptions(numberId, version));

        return HttpResult.From(result);
    }

    private static MetaOptions CreateOptions(string numberId, string version)
    {
        return new MetaOptions(numberId, NormalizeVersion(version));
    }

    private static string NormalizeVersion(string version)
    {
        return string.IsNullOrWhiteSpace(version) ? "v25.0" : version;
    }
}
