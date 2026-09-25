namespace Domain.Dtos;

public record AdvanceSettings
(
    bool? AlwaysOnline = true,
    bool? IgnoreGroups = true,
    bool? IgnoreStatus = true,
    bool? ReadMessages = true,
    bool? RejectCall = true
);

public record CreateInstanceDto
(
    string Name,
    string? Token,
    AdvanceSettings? AdvanceSettings
);