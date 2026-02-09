namespace Volunteer.Domain.ValueObjects;

public sealed record Document
{
    public string Type { get; init; } = string.Empty;
    public string Number { get; init; } = string.Empty;
    public DateTimeOffset IssuedAt { get; init; }
    public DateTimeOffset? ExpiresAt { get; init; }
    public string FileUrl { get; init; } = string.Empty;
}