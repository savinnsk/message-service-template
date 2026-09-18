using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Services.Providers.EvolutionGo;

namespace Application.Controllers;

[ApiController]
[Route("api/evogo/message")]
public class MessageController(MessageService messageWhatsappService) : ControllerBase
{
    [HttpPost("{tokenInstance}")]
    public async Task<IActionResult> SendTextMessage(string tokenInstance, [FromBody] TextMessage textMessage)
    {
        var result = await messageWhatsappService.SendText(tokenInstance, textMessage);
        return HttpResult.From(result);
    }

    [HttpPost("link/{tokenInstance}")]
    public async Task<IActionResult> SendLinkMessage(string tokenInstance, [FromBody] TextMessage linkMessage)
    {
        var result = await messageWhatsappService.SendLink(tokenInstance, linkMessage);
        return HttpResult.From(result);
    }

    [HttpPost("media/{tokenInstance}")]
    public async Task<IActionResult> SendMediaMessage(string tokenInstance, [FromBody] MediaMessage mediaMessage)
    {
        var result = await messageWhatsappService.SendMedia(tokenInstance, mediaMessage);
        return HttpResult.From(result);
    }

    //unstable
    [HttpPost("button/{tokenInstance}")]
    public async Task<IActionResult> SendButtonMessage(string tokenInstance, [FromBody] ButtonMessage buttonMessage)
    {
        var result = await messageWhatsappService.SendButton(tokenInstance, buttonMessage);
        return HttpResult.From(result);
    }

    [HttpPost("list/{tokenInstance}")]
    public async Task<IActionResult> SendListMessage(string tokenInstance, [FromBody] ListMessage listMessage)
    {
        var result = await messageWhatsappService.SendList(tokenInstance, listMessage);
        return HttpResult.From(result);
    }
}
