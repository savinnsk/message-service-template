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
    
    [HttpPost("link/{tokenInstance}")]
    public async Task<IActionResult> SendLinkMessage(string tokenInstance,[FromBody] TextMessage linkMessage)
    {
        
        var result = await _messageWhatsappService.SendLink(tokenInstance,linkMessage);
        
        if(!result.Success)
            return StatusCode(result.StatusCode, result.Error);

        var json = JsonSerializer.Deserialize<JsonElement>(result.Data!);
            
        return StatusCode(result.StatusCode, json);
    }
    
    [HttpPost("media/{tokenInstance}")]
    public async Task<IActionResult> SendMediaMessage(string tokenInstance,[FromBody] MediaMessage mediaMessage)
    {
        var result = await _messageWhatsappService.SendMedia(tokenInstance,mediaMessage);
        
        if(!result.Success)
            return StatusCode(result.StatusCode, result.Error);

        var json = JsonSerializer.Deserialize<JsonElement>(result.Data!);
            
        return StatusCode(result.StatusCode, json);
    }
    
    //unstable
    [HttpPost("button/{tokenInstance}")]
    public async Task<IActionResult> SendButtonMessage(string tokenInstance,[FromBody] ButtonMessage buttonMessage)
    {
        
        var result = await _messageWhatsappService.SendButton(tokenInstance,buttonMessage);
        
        if(!result.Success)
            return StatusCode(result.StatusCode, result.Error);

        var json = JsonSerializer.Deserialize<JsonElement>(result.Data!);
            
        return StatusCode(result.StatusCode, json);
    }
    
    [HttpPost("list/{tokenInstance}")]
    public async Task<IActionResult> SendListMessage(string tokenInstance,[FromBody] ListMessage listMessage)
    {
        
        var result = await _messageWhatsappService.SendList(tokenInstance,listMessage);
        
        if(!result.Success)
            return StatusCode(result.StatusCode, result.Error);

        var json = JsonSerializer.Deserialize<JsonElement>(result.Data!);
            
        return StatusCode(result.StatusCode, json);
    }
    
}