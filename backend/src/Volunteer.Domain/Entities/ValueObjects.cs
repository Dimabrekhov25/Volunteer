namespace Volunteer.Domain.Entities;

public sealed record Location
{
    public string AddressLine { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string Region { get; init; } = string.Empty;
    public string PostalCode { get; init; } = string.Empty;
    public double? Latitude { get; init; }
    public double? Longitude { get; init; }
}

public sealed record Contact
{
    public string Name { get; init; } = string.Empty;
    public string Phone { get; init; } = string.Empty;
    public string? Email { get; init; }
}

public sealed record TimeWindow
{
    public DateTimeOffset From { get; init; }
    public DateTimeOffset To { get; init; }
}

public sealed record Document
{
    public string Type { get; init; } = string.Empty;
    public string Number { get; init; } = string.Empty;
    public DateTimeOffset IssuedAt { get; init; }
    public DateTimeOffset? ExpiresAt { get; init; }
    public string FileUrl { get; init; } = string.Empty;
}
