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
    public async Task<IActionResult> CreateInstance([FromBody] CreateInstanceDto data)
    {
        var result = await _instanceService.CreateInstance(data);
        return HttpResult.From(result);
    }

    [HttpGet("qr/{instanceName}")]
    public async Task<IActionResult> ConnectQr(string instanceName)
    {
        var result = await _instanceService.ConnectQr(instanceName);
        return HttpResult.From(result);
    }

    [HttpGet("status/{instanceToken}")]
    public async Task<IActionResult> GetStatus(string instanceToken)
    {
        var result = await _instanceService.GetStatus(instanceToken);
        return HttpResult.From(result);
    }

    [HttpDelete("delete/{instanceId}")]
    public async Task<IActionResult> Delete(string instanceId)
    {
        var result = await _instanceService.Delete(instanceId);
        return HttpResult.From(result);
    }

    [HttpPost("disconnect/{instanceToken}")]
    public async Task<IActionResult> Disconnect(string instanceToken)
    {
        var result = await _instanceService.Disconnect(instanceToken);
        return HttpResult.From(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _instanceService.GetAll();
        return HttpResult.From(result);
    }

    [HttpGet("get/{instanceId}")]
    public async Task<IActionResult> Get(string instanceId)
    {
        var result = await _instanceService.Get(instanceId);
        return HttpResult.From(result);
    }
}
