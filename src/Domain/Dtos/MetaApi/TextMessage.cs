using System.Text.Json.Serialization;

namespace Domain.Dtos.MetaApi;

public record TextMessage(
    [property: JsonPropertyName("to")] string To,
    [property: JsonPropertyName("text")] Text? Text,
    [property: JsonPropertyName("type")] string? Type = "text",
    [property: JsonPropertyName("recipient_type")] string? RecipientType = "individual",
    [property: JsonPropertyName("messaging_product")] string? MessagingProduct = "whatsapp"
    );


public record Text(
    [property: JsonPropertyName("body")] string? Body,
    [property: JsonPropertyName("preview_url")] bool? PreviewUrl = false
);