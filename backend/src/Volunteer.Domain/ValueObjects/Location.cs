namespace Volunteer.Domain.ValueObjects;

public sealed record Location
{
    public string AddressLine { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string Region { get; init; } = string.Empty;
    public string PostalCode { get; init; } = string.Empty;
    public double? Latitude { get; init; }
    public double? Longitude { get; init; }
}