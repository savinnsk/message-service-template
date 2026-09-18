using Domain.Dtos.MetaApi;
using Microsoft.AspNetCore.Mvc;
using Services.Providers.MetaApi;

namespace Application.Controllers.MetaApi;

[ApiController]
[Route("api/meta")]
public class MetaWebhookController(IConfiguration configuration) : ControllerBase
{
    [HttpGet("webhook")]
    public IActionResult Verify(){
        
        var hubChallengeToken = Request.Query["hub.challenge"].FirstOrDefault() ?? Request.Query["hub_challenge"].FirstOrDefault();
        var hubMode = Request.Query["hub.mode"].FirstOrDefault() ?? Request.Query["hub_mode"].FirstOrDefault() ;
        var hubVerifyToken = Request.Query["hub.verify_token"].FirstOrDefault() ?? Request.Query["hub_verify_token"].FirstOrDefault();
        var expectedToken = configuration["MetaApi:WebhookVerifyToken"];
        
        if (hubMode == "subscribe" && hubVerifyToken == expectedToken)
        {
            return Content(hubChallengeToken,"text/plain");
        }
        
        return Unauthorized();
    }

    [HttpPost("webhook")]
    public IActionResult ReceiveWebhook([FromBody] MetaWebhookPayload payload)
    {
        
        var inboundMessages = new MetaWebhook().Mapper(payload);

        //foreach (var bound in  inboundMessages)
        //{
        //    Console.WriteLine($"[{bound.Provider}] {bound.SenderName} ({bound.SenderId})");   
       // }

        return Ok();
    }
}