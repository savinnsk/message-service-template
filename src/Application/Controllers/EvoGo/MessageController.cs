using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using Services.Providers.EvolutionGo;

namespace Application.Controllers;

[ApiController]
[Route("api/evogo/message")]
public class MessageController(MessageService messageWhatsappService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SendTextMessage(
        [FromHeader(Name = "x-evogo-token")] string evoGoToken,
        [FromBody] TextMessage textMessage)
    {
        var result = await messageWhatsappService.SendText(evoGoToken, textMessage);
        return HttpResult.From(result);
    }

    [HttpPost("link")]
    public async Task<IActionResult> SendLinkMessage(
        [FromHeader(Name = "x-evogo-token")] string evoGoToken,
        [FromBody] TextMessage linkMessage)
    {
        var result = await messageWhatsappService.SendLink(evoGoToken, linkMessage);
        return HttpResult.From(result);
    }

    [HttpPost("media")]
    public async Task<IActionResult> SendMediaMessage(
        [FromHeader(Name = "x-evogo-token")] string evoGoToken,
        [FromBody] MediaMessage mediaMessage)
    {
        var result = await messageWhatsappService.SendMedia(evoGoToken, mediaMessage);
        return HttpResult.From(result);
    }

    //unstable
    [HttpPost("button")]
    public async Task<IActionResult> SendButtonMessage(
        [FromHeader(Name = "x-evogo-token")] string evoGoToken,
        [FromBody] ButtonMessage buttonMessage)
    {
        var result = await messageWhatsappService.SendButton(evoGoToken, buttonMessage);
        return HttpResult.From(result);
    }

    [HttpPost("list")]
    public async Task<IActionResult> SendListMessage(
        [FromHeader(Name = "x-evogo-token")] string evoGoToken,
        [FromBody] ListMessage listMessage)
    {
        var result = await messageWhatsappService.SendList(evoGoToken, listMessage);
        return HttpResult.From(result);
    }
}
