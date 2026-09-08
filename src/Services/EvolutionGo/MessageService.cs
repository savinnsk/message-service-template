using Domain.Dtos;
using Domain.Records;
using Infra.EvolutionGo;

namespace Services.EvolutionGo;

public class MessageService
{
    EvolutionGoIntegration _evolutionGoIntegration;

    public MessageService(EvolutionGoIntegration evolutionGoIntegration)
    {
        _evolutionGoIntegration = evolutionGoIntegration;
    }

    public Task<Result<string>> SendText(string tokenInstance,TextMessage msg)
    {
         return  _evolutionGoIntegration.SendText(tokenInstance,msg);
    }
    
    public Task<Result<string>> SendMedia(string tokenInstance,MediaMessage msg)
    {
        return  _evolutionGoIntegration.SendMedia(tokenInstance,msg);
    }
    
    public Task<Result<string>> SendLink(string tokenInstance,TextMessage msg)
    {
        return  _evolutionGoIntegration.SendLink(tokenInstance,msg);
    }
    
    //unstable
    public Task<Result<string>> SendButton(string tokenInstance,ButtonMessage msg)
    {
        return  _evolutionGoIntegration.SendButton(tokenInstance,msg);
    }
    
    public Task<Result<string>> SendList(string tokenInstance,ListMessage msg)
    {
        return  _evolutionGoIntegration.SendList(tokenInstance,msg);
    }
}