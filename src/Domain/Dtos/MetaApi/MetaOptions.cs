using System.Text.Json.Serialization;

namespace Domain.Dtos.MetaApi;

public record MetaOptions(
    [property: JsonPropertyName("number_id")] string NumberId,
    [property: JsonPropertyName("version")] string Version = "v25.0"
    );