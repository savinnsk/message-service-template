using Domain.Dtos.MetaApi;
using Domain.Records;

namespace Services.Providers.MetaApi;

public class MetaWebhook
{
    public  List<InboundMessageRequest> Mapper(MetaWebhookPayload payload)
    {
        var inboundMessages = payload.Entry
            .SelectMany(entry => entry.Changes)
            .Where(change => change.Field == "messages")
            .SelectMany(change =>
            {
                var value = change.Value;
                var messages = value.Messages ?? [];
              
                return messages.Select(message =>
                {
                    var contact = value.Contacts?.FirstOrDefault(contact => contact.WaId == message.From);
                    return new InboundMessageRequest
                    {
                        Provider = "meta",
                        Channel = value.MessagingProduct,
                        ChannelId = value.Metadata.PhoneNumberId,
                        ChannelDisplayPhoneNumber = value.Metadata.DisplayPhoneNumber,
                        SenderId = message.From,
                        SenderName = contact?.Profile.Name,
                        ExternalMessageId =  message.Id,
                        Type = message.Type,
                        Content = message.Type switch
                        {
                            "text" => message.Text?.Body,
                            "interactive" when message.Interactive?.ButtonReply is not null => message.Interactive.ButtonReply.Title,
                            "interactive" when message.Interactive?.ListReply is not null => message.Interactive.ListReply.Title,
                            _ => null
                        },
                        ReplyId = message.Interactive?.ButtonReply?.Id
                                  ?? message.Interactive?.ListReply?.Id,

                        ReplyTitle = message.Interactive?.ButtonReply?.Title
                                     ?? message.Interactive?.ListReply?.Title,

                        ReplyDescription = message.Interactive?.ListReply?.Description,
                        Timestamp = DateTimeOffset.FromUnixTimeSeconds(long.Parse(message.Timestamp))
                    };
                });
            }).ToList();

        return inboundMessages;
    }
}