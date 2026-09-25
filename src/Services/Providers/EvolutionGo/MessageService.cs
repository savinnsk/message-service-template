using Domain.Dtos;
using Domain.Records;
using Infra.Providers.EvolutionGo;

namespace Services.Providers.EvolutionGo;

public class MessageService
{
    EvolutionGoIntegration _evolutionGoIntegration;

    public MessageService(EvolutionGoIntegration evolutionGoIntegration)
    {
        _evolutionGoIntegration = evolutionGoIntegration;
    }

    public Task<Result<string>> SendText(string evoGoToken,TextMessage msg)
    {
         return  _evolutionGoIntegration.SendText(evoGoToken,msg);
    }
    
    public Task<Result<string>> SendMedia(string evoGoToken,MediaMessage msg)
    {
        return  _evolutionGoIntegration.SendMedia(evoGoToken,msg);
    }
    
    public Task<Result<string>> SendLink(string evoGoToken,TextMessage msg)
    {
        return  _evolutionGoIntegration.SendLink(evoGoToken,msg);
    }
    
    //unstable
    public Task<Result<string>> SendButton(string evoGoToken,ButtonMessage msg)
    {
        return  _evolutionGoIntegration.SendButton(evoGoToken,msg);
    }
    
    public Task<Result<string>> SendList(string evoGoToken,ListMessage msg)
    {
        return  _evolutionGoIntegration.SendList(evoGoToken,msg);
    }
}
