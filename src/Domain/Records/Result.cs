namespace Domain.Records;

public record Result<T>
(
    bool Success,
    T? Data,
    string? Error,
    int StatusCode
);