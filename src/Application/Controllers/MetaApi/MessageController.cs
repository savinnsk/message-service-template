using Domain.Dtos.MetaApi;
using Microsoft.AspNetCore.Mvc;
using Services.Providers.MetaApi;

namespace Application.Controllers.MetaApi;

[ApiController]
[Route("api/meta/{numberId}/message")]
public class MessageController(MessageService messageService) : ControllerBase
{
    [HttpPost("text")]
    public async Task<IActionResult> SendText(
        string numberId,
        [FromHeader(Name = "x-meta-token")] string metaToken,
        [FromHeader(Name = "x-meta-version")] string version,
        [FromBody] TextMessage message)
    {
      var result = await messageService.SendText(metaToken, CreateOptions(numberId, version), message);   
      
      return HttpResult.From(result);
    } 
    
    [HttpPost("list")]
    public async Task<IActionResult> SendList(
        string numberId,
        [FromHeader(Name = "x-meta-token")] string metaToken,
        [FromHeader(Name = "x-meta-version")] string version,
        [FromBody] InteractiveMessage message)
    {
        var result = await messageService.SendInteractive(metaToken, CreateOptions(numberId, version), message);   
      
        return HttpResult.From(result);
    } 
    
    [HttpPost("button")]
    public async Task<IActionResult> SendButton(
        string numberId,
        [FromHeader(Name = "x-meta-token")] string metaToken,
        [FromHeader(Name = "x-meta-version")] string version,
        [FromBody] InteractiveMessage message)
    {
        var result = await messageService.SendInteractive(metaToken, CreateOptions(numberId, version), message);   
      
        return HttpResult.From(result);
    }

    private static MetaOptions CreateOptions(string numberId, string version)
    {
        return new MetaOptions(numberId, string.IsNullOrWhiteSpace(version) ? "v25.0" : version);
    }
}
