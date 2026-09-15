using Domain.Dtos.MetaApi;
using Microsoft.AspNetCore.Mvc;
using Services.MetaApi;

namespace Application.Controllers.MetaApi;


using System.Text.Json.Serialization;

public record SendMessageRequest<TMessage>(
    [property: JsonPropertyName("options")] MetaOptions Options,
    [property: JsonPropertyName("message")] TMessage Message
);

[ApiController]
[Route("api/meta/message")]
public class MessageController(MessageService messageService) : ControllerBase
{
    [HttpPost("text")]
    public async Task<IActionResult> SendText([FromBody] SendMessageRequest<TextMessage> request)
    {
      var result = await messageService.SendText(request.Options, request.Message);   
      
      return HttpResult.From(result);
    } 
    
    [HttpPost("list")]
    public async Task<IActionResult> SendList([FromBody] SendMessageRequest<InteractiveMessage>request)
    {
        var result = await messageService.SendInteractive(request.Options, request.Message);   
      
        return HttpResult.From(result);
    } 
    
    [HttpPost("button")]
    public async Task<IActionResult> SendButton([FromBody] SendMessageRequest<InteractiveMessage>request)
    {
        var result = await messageService.SendInteractive(request.Options, request.Message);   
      
        return HttpResult.From(result);
    } 
    
}
