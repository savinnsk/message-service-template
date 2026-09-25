using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Services.Providers.EvolutionGo;

namespace Application.Controllers;

[ApiController]
[Route("api/evogo/instance")]
public class InstanceController : ControllerBase
{
    private readonly InstanceService _instanceService;

    public InstanceController(InstanceService instanceService)
    {
        _instanceService = instanceService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateInstance(
        [FromHeader(Name = "x-evogo-token")] string evoGoToken,
        [FromBody] CreateInstanceDto data)
    {
        var result = await _instanceService.CreateInstance(evoGoToken, data);
        return HttpResult.From(result);
    }

    [HttpGet("qr")]
    public async Task<IActionResult> ConnectQr([FromHeader(Name = "x-evogo-token")] string evoGoToken)
    {
        var result = await _instanceService.ConnectQr(evoGoToken);
        return HttpResult.From(result);
    }

    [HttpGet("status")]
    public async Task<IActionResult> GetStatus([FromHeader(Name = "x-evogo-token")] string evoGoToken)
    {
        var result = await _instanceService.GetStatus(evoGoToken);
        return HttpResult.From(result);
    }

    [HttpDelete("delete/{instanceId}")]
    public async Task<IActionResult> Delete(
        string instanceId,
        [FromHeader(Name = "x-evogo-token")] string evoGoToken)
    {
        var result = await _instanceService.Delete(evoGoToken, instanceId);
        return HttpResult.From(result);
    }

    [HttpPost("disconnect")]
    public async Task<IActionResult> Disconnect([FromHeader(Name = "x-evogo-token")] string evoGoToken)
    {
        var result = await _instanceService.Disconnect(evoGoToken);
        return HttpResult.From(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromHeader(Name = "x-evogo-token")] string evoGoToken)
    {
        var result = await _instanceService.GetAll(evoGoToken);
        return HttpResult.From(result);
    }

    [HttpGet("get/{instanceId}")]
    public async Task<IActionResult> Get(
        string instanceId,
        [FromHeader(Name = "x-evogo-token")] string evoGoToken)
    {
        var result = await _instanceService.Get(evoGoToken, instanceId);
        return HttpResult.From(result);
    }
}
