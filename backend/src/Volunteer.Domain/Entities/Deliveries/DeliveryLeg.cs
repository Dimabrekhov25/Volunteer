using Volunteer.Domain.Enums;
using Volunteer.Domain.ValueObjects;

namespace Volunteer.Domain.Entities;

public sealed class DeliveryLeg
{
    public int Index { get; set; }
    public Location? FromLocation { get; set; }
    public Location? ToLocation { get; set; }
    public DeliveryStatus Status { get; set; } = DeliveryStatus.Created;
    public DateTimeOffset? PickupTime { get; set; }
    public DateTimeOffset? DropoffTime { get; set; }
}
