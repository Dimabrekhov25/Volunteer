using Volunteer.Domain.Enums;
using Volunteer.Domain.ValueObjects;

namespace Volunteer.Domain.Entities;

public sealed class VolunteerProfile
{
    public Guid Id { get; init; }
    public Guid UserId { get; init; }
    public VolunteerVerificationStatus VerificationStatus { get; set; } = VolunteerVerificationStatus.Pending;
    public VolunteerAvailabilityStatus AvailabilityStatus { get; set; } = VolunteerAvailabilityStatus.Offline;
    public VehicleType? VehicleType { get; set; }
    public int? Capacity { get; set; }
    public List<string> SpeciesAllowed { get; set; } = new();
    public Location? HomeBaseLocation { get; set; }
    public string? Experience { get; set; }
    public Contact? EmergencyContact { get; set; }
    public decimal Rating { get; set; }
    public int CompletedTripsCount { get; set; }
}
