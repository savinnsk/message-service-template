namespace Domain.Records;

public record InboundMessageRequest
{
    public string Provider { get; init; } = string.Empty;
    public string? ReplyId { get; init; }
    public string? ReplyTitle { get; init; }
    public string? ReplyDescription { get; init; }
    public string Channel { get; init; } = string.Empty;
    public string ChannelDisplayPhoneNumber { get; init; } = string.Empty;
    public string ChannelId { get; init; } = string.Empty;
    public string SenderId { get; init; } = string.Empty;
    public string? SenderName { get; init; }
    public string ExternalMessageId { get; init; } = string.Empty;
    public string Type { get; init; } = string.Empty;
    public string? Content { get; init; }
    public DateTimeOffset Timestamp { get; init; }
}