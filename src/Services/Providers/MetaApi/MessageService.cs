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
    public Task<Result<string>> SendText(MetaOptions options, TextMessage textMessage )
    {
        return _metaApiMessage.SendText(options, textMessage);
    }
    
    
    public Task<Result<string>> SendInteractive(MetaOptions options, InteractiveMessage message )
    {
        return _metaApiMessage.SendList(options, message);
    }
    
}