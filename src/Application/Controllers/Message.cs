using System.Text.Json;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using message_service.Services;

namespace Application.Controllers;

[ApiController]
[Route("api/instance")]
public class MessageController : ControllerBase
{
    private readonly InstanceService _instanceService;

    public MessageController(InstanceService instanceService)
    {
        _instanceService = instanceService;
    }
    
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateInstance([FromBody] CreateInstanceDto data)
    {
        var result = await _instanceService.CreateInstance(data);
        
        if (!result.Success)
            return StatusCode(result.StatusCode, result.Error);
        
        using var document = JsonDocument.Parse(result.Data!);
        
        return StatusCode(result.StatusCode, document.RootElement);
    }
}