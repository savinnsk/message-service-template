using System.Text.Json.Serialization;

namespace Domain.Dtos.MetaApi;

public record InteractiveMessage(
    [property: JsonPropertyName("to")] string To,
    [property: JsonPropertyName("interactive")] Interactive Interactive,
    [property: JsonPropertyName("type")] string? Type = "interactive",
    [property: JsonPropertyName("recipient_type")] string? RecipientType = "individual",
    [property: JsonPropertyName("messaging_product")] string? MessagingProduct = "whatsapp"
    );

public record Interactive(
    [property: JsonPropertyName("header")] Header? Header,
    [property: JsonPropertyName("body")] Body? Body,
    [property: JsonPropertyName("footer")] Footer? Footer,
    [property: JsonPropertyName("action")] Action Action,
    [property: JsonPropertyName("type")] string Type = "list"
    
    );
        
public record Header(
    [property: JsonPropertyName("text")] string? Text,
    [property: JsonPropertyName("type")] string? Type = "text"
    );
    
public record Body(
    [property: JsonPropertyName("text")] string? Text
);

public record Footer(
    [property: JsonPropertyName("text")] string? Text
);


public record Action(
    [property: JsonPropertyName("button")] string? Text,
    [property: JsonPropertyName("sections")] List<Section>? Section,
    [property: JsonPropertyName("buttons")] List<Button>? Button
);

public record Section(
    [property: JsonPropertyName("title")] string? Title,
    [property: JsonPropertyName("rows")] List<Row> Rows
);

public record Row(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("description")] string? Description
);