using Domain.Dtos.MetaApi;
using Domain.Records;
using Infra.Providers.Meta;

namespace Services.Providers.MetaApi;

public class MessageService
{
    private readonly MetaApiMessage _metaApiMessage;
    
    public MessageService(MetaApiMessage metaApiMessage)
    {
        _metaApiMessage = metaApiMessage;
    }
    public Task<Result<string>> SendText(string metaToken, MetaOptions options, TextMessage textMessage )
    {
        return _metaApiMessage.SendText(metaToken, options, textMessage);
    }
    
    
    public Task<Result<string>> SendInteractive(string metaToken, MetaOptions options, InteractiveMessage message )
    {
        return _metaApiMessage.SendList(metaToken, options, message);
    }
    
}
