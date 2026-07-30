using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Services.MessageWhatsapp;
using System.Text.Json;
namespace Application.Controllers;

[ApiController]
[Route("api/message")]
public class MessageWhatsappController : ControllerBase
{
    private readonly MessageWhatsappService _messageWhatsappService;

    public MessageWhatsappController(MessageWhatsappService messageWhatsappService)
    {
        _messageWhatsappService = messageWhatsappService;
    }

    [HttpPost("{tokenInstance}")]
    public async Task<IActionResult> SendTextMessage(string tokenInstance,[FromBody] TextMessage textMessage)
    {
        
        var result = await _messageWhatsappService.SendText(tokenInstance,textMessage);
        
        if(!result.Success)
            return StatusCode(result.StatusCode, result.Error);

        var json = JsonSerializer.Deserialize<JsonElement>(result.Data!);
            
        return StatusCode(result.StatusCode, json);
    }
}