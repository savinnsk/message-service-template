using System.Text.Json.Serialization;

namespace Domain.Dtos.MetaApi;


public record Button(
    [property: JsonPropertyName("reply")]  Reply Reply,
    [property: JsonPropertyName("type")] string? Type = "reply"
);

public record Reply(
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("id")] string Id
);