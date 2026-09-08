namespace Domain.Dtos;



public record TextMessage(
    string Number,
    string Text,
    int? Delay,
    string? MentionedJid,
    bool? MentionAll,
    QuotedMessage? Quoted

);


public record MediaMessage(
    string Number,
    string Url,
    string? Caption = null,
    string? Filename = null,
    string Type = "document",
    int? Delay = null,
    string? MentionedJid = null,
    bool? MentionAll = null,
    QuotedMessage? Quoted = null

);

public record QuotedMessage(
    string MessageId,
    string Participant

);



public record ListMessage(

    string Number,

    string Title,

    string Description,

    string ButtonText,

    string FooterText,

    List<ListSection> Sections,

    int? Delay = null,

    string? MentionedJid = null,

    bool? MentionAll = null,

    QuotedMessage? Quoted = null

);

public record ListSection(

    string Title,

    List<ListRow> Rows

);

public record ListRow(

    string Title,

    string Description,

    string RowId

);