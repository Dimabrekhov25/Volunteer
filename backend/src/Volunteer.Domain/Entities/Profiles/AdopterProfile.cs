using Volunteer.Domain.ValueObjects;

namespace Volunteer.Domain.Entities;

public sealed class AdopterProfile
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public Location? Address { get; set; }
    public string? FamilyInfo { get; set; }
    public string? Experience { get; set; }
    public string? Availability { get; set; }
    public string? Notes { get; set; }
}
