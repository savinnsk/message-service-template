using System.Text.Json;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using message_service.Services;

namespace Application.Controllers;

[ApiController]
[Route("api/instance")]
public class InstanceWhatsappController : ControllerBase
{
    private readonly InstanceService _instanceService;

    public InstanceWhatsappController(InstanceService instanceService)
    {
        _instanceService = instanceService;
    }
    
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateInstance([FromBody] CreateInstanceDto data)  
    {
        var result = await _instanceService.CreateInstance(data);
        
        if (!result.Success)
            return StatusCode(result.StatusCode, result.Error);
        
        var json = JsonSerializer.Deserialize<JsonElement>(result.Data!);
        
        return StatusCode(result.StatusCode, json);
    }
    
    [HttpGet("qr/{instanceName}")]
    public async Task<IActionResult> ConnectQr(string instanceName)
    {
        var result = await _instanceService.ConnectQr(instanceName);
        
        if (!result.Success)
            return StatusCode(result.StatusCode, result.Error);
        
        var json = JsonSerializer.Deserialize<JsonElement>(result.Data!);
        
        return StatusCode(result.StatusCode, json);
    }
    
    
    [HttpGet("status/{instanceName}")]
    public async Task<IActionResult> GetStatus(string instanceName)
    {
        var result = await _instanceService.GetStatus(instanceName);
        
        if (!result.Success)
            return StatusCode(result.StatusCode, result.Error);
        
        var json = JsonSerializer.Deserialize<JsonElement>(result.Data!);
        
        return StatusCode(result.StatusCode, json);
    }
    
    //TODO
    [HttpDelete("delete/{instanceId}")]
    public async Task<IActionResult> Delete(string instanceId)
    {
        var result = await _instanceService.Delete(instanceId);
        
        if (!result.Success)
            return StatusCode(result.StatusCode, result.Error);
        
        var json = JsonSerializer.Deserialize<JsonElement>(result.Data!);
        
        return StatusCode(result.StatusCode, json);
    }
    
    //TODO
    // [HttpPost("disconnect/")]
    // public async Task<IActionResult> Disconnect()
    // {
    //     var result = await _instanceService.Disconnect();
    //     
    //     if (!result.Success)
    //         return StatusCode(result.StatusCode, result.Error);
    //     
    //     var json = JsonSerializer.Deserialize<JsonElement>(result.Data!);
    //     
    //     return StatusCode(result.StatusCode, json);
    // }
    
    
    //TODO
    // [HttpGet("/")]
    // public async Task<IActionResult> GetAll()
    // {
    //     var result = await _instanceService.GetAll();
    //     
    //     if (!result.Success)
    //         return StatusCode(result.StatusCode, result.Error);
    //     
    //     var json = JsonSerializer.Deserialize<JsonElement>(result.Data!);
    //     
    //     return StatusCode(result.StatusCode, json);
    // }
    
    
    //TODO
    // [HttpGet("/get/{instanceId}")]
    // public async Task<IActionResult> Get(string instanceId)
    // {
    //     var result = await _instanceService.Get(instanceId);
    //     
    //     if (!result.Success)
    //         return StatusCode(result.StatusCode, result.Error);
    //     
    //     var json = JsonSerializer.Deserialize<JsonElement>(result.Data!);
    //     
    //     return StatusCode(result.StatusCode, json);
    // }
}