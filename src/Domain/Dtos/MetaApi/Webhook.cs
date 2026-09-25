using System.Text.Json.Serialization;

namespace Domain.Dtos.MetaApi;

public record MetaWebhookPayload(
    [property:JsonPropertyName("object")] string Object,
    [property:JsonPropertyName("entry")] List<Entry> Entry
    );
    
public record Entry(
    [property:JsonPropertyName("id")] string Id,
    [property:JsonPropertyName("changes")] List<Changes> Changes
);

public record Changes(
    [property:JsonPropertyName("field")] string Field,
    [property:JsonPropertyName("value")] Value Value
);

public record Value(
    [property:JsonPropertyName("messaging_product")] string MessagingProduct,
    [property:JsonPropertyName("metadata")] Metadata Metadata,
    [property:JsonPropertyName("contacts")] List<Contacts>? Contacts,
    [property:JsonPropertyName("messages")] List<Messages>? Messages
);

public record Metadata(
    [property:JsonPropertyName("display_phone_number")] string DisplayPhoneNumber,
    [property:JsonPropertyName("phone_number_id")] string PhoneNumberId
);

public record Contacts(
    [property:JsonPropertyName("wa_id")] string WaId,
    [property:JsonPropertyName("user_id")] string UserId,
    [property:JsonPropertyName("profile")] Profile Profile
    );

public record Profile(
    [property: JsonPropertyName("name")] string Name
);

public record Messages(
    [property: JsonPropertyName("from")] string From,
    [property: JsonPropertyName("from_user_id")] string? FromUserId,
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("timestamp")] string Timestamp,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("text")] TextWebhook? Text,
    [property: JsonPropertyName("interactive")] InteractiveWebhook? Interactive
);

public record TextWebhook(
    [property: JsonPropertyName("body")] string Body
);    

public record InteractiveWebhook(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("button_reply")] ButtonReplyWebhook? ButtonReply,
    [property: JsonPropertyName("list_reply")] ListReplyWebhook? ListReply
);

public record ButtonReplyWebhook(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("title")] string Title
);

public record ListReplyWebhook(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("description")] string? Description
);