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
    
    
    [HttpGet("status/{instanceToken}")]
    public async Task<IActionResult> GetStatus(string instanceToken)
    {
        var result = await _instanceService.GetStatus(instanceToken);
        
        if (!result.Success)
            return StatusCode(result.StatusCode, result.Error);
        
        var json = JsonSerializer.Deserialize<JsonElement>(result.Data!);
        
        return StatusCode(result.StatusCode, json);
    }
    
    
    [HttpDelete("delete/{instanceId}")]
    public async Task<IActionResult> Delete(string instanceId)
    {
        var result = await _instanceService.Delete(instanceId);
        
        if (!result.Success)
            return StatusCode(result.StatusCode, result.Error);
        
        var json = JsonSerializer.Deserialize<JsonElement>(result.Data!);
        
        return StatusCode(result.StatusCode, json);
    }
    
    
     [HttpPost("disconnect/{instanceToken}")]
     public async Task<IActionResult> Disconnect(string instanceToken)
     {
         var result = await _instanceService.Disconnect(instanceToken);
         
         if (!result.Success)
             return StatusCode(result.StatusCode, result.Error);
         
         var json = JsonSerializer.Deserialize<JsonElement>(result.Data!);
         
         return StatusCode(result.StatusCode, json);
     }
    
    
    
     [HttpGet()]
     public async Task<IActionResult> GetAll()
     {
         var result = await _instanceService.GetAll();
         
         if (!result.Success)
             return StatusCode(result.StatusCode, result.Error);
         
         var json = JsonSerializer.Deserialize<JsonElement>(result.Data!);
         
         return StatusCode(result.StatusCode, json);
     }
    
     
     [HttpGet("/get/{instanceId}")]
     public async Task<IActionResult> Get(string instanceId)
     {
         var result = await _instanceService.Get(instanceId);
         
         if (!result.Success)
             return StatusCode(result.StatusCode, result.Error);
         
         var json = JsonSerializer.Deserialize<JsonElement>(result.Data!);
         
         return StatusCode(result.StatusCode, json);
     }
}