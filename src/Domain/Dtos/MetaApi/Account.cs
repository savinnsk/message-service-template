using System.Text.Json.Serialization;

namespace Domain.Dtos.MetaApi;

public record RegisterPhoneNumberDto(
    [property:JsonPropertyName("messaging_product")] string MessagingProduct,
    [property:JsonPropertyName("pin")] string Pin
    );
    
    
public record RequestVerificationCodeDto(
    [property:JsonPropertyName("code_method")] string CodeMethod,
    [property:JsonPropertyName("locale")] string Locale
);

public record VerifyCodeDto(
    [property:JsonPropertyName("code")] string Code
);

public record SetTwoTepVerificationCodeDto(
    [property:JsonPropertyName("pin")] string Code
);