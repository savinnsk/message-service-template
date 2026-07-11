using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using message_service.Infra.EvolutionGo;

namespace Application.Controllers;

[ApiController]
[Route("api/message")]
public class MessageController : ControllerBase
{
    private readonly EvolutionGoIntegration _evolutionGoIntegration;

    public MessageController(EvolutionGoIntegration evolutionGoIntegration)
    {
        _evolutionGoIntegration = evolutionGoIntegration;
    }
    
    
    [HttpPost("create-instance")]
    public async Task<IActionResult> CreateInstance([FromBody] CreateInstanceDto data)
    {
        var result = await _evolutionGoIntegration.CreateInstance(data);

        if (!result.Success)
            return StatusCode(result.StatusCode, result.Error);
        
        return StatusCode(result.StatusCode, result.Data);
    }
}