namespace Domain.Dtos;


public enum ButtonType
{
    Reply,
    Copy,
    Url,
    Call,
    Pix
}




public abstract record Button(
    ButtonType Type
);


public record ReplyButton(
    string DisplayText,
    string Id
) : Button(ButtonType.Reply);

public record UrlButton(
    string DisplayText,
    string Url
) : Button(ButtonType.Url);

public record CallButton(
    string DisplayText,
    string PhoneNumber
) : Button(ButtonType.Call);

public record CopyButton(
    string DisplayText,
    string CopyCode
) : Button(ButtonType.Copy);

public record PixButton(
    string Currency,
    string Name,
    string KeyType,
    string Key
) : Button(ButtonType.Pix);



public record ButtonMessage(
    string Number,
    string Title,
    string Description,
    string Footer,
    List<Button> Buttons,
    int? Delay = null,
    string? MentionedJid = null,
    bool? MentionAll = null,
    QuotedMessage? Quoted = null
);