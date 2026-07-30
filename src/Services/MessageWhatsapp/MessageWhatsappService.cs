using Domain.Dtos;
using Domain.Records;
using message_service.Infra.EvolutionGo;

namespace Services.MessageWhatsapp;

public class MessageWhatsappService
{
    EvolutionGoIntegration _evolutionGoIntegration;

    public MessageWhatsappService(EvolutionGoIntegration evolutionGoIntegration)
    {
        _evolutionGoIntegration = evolutionGoIntegration;
    }

    public Task<Result<string>> SendText(string tokenInstance,TextMessage msg)
    {
         return  _evolutionGoIntegration.SendText(tokenInstance,msg);
    }
}