using Volunteer.Domain.Entities;
using Volunteer.Domain.Entities.Users;
using Volunteer.Domain.Enums;
using Volunteer.Domain.ValueObjects;

namespace Volunteer.Domain.Entities.Profiles;

public sealed class VolunteerProfile : BaseEntity
{
    public Guid UserId { get; init; }
    public User User { get; set; } = null!;
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
