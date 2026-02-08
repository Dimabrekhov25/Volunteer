using Volunteer.Domain.Enums;

namespace Volunteer.Domain.Entities;

public sealed class Delivery
{
    public Guid Id { get; init; }
    public Guid AnimalId { get; init; }
    public Guid CreatedByUserId { get; init; }
    public Guid? AssignedVolunteerId { get; set; }
    public Location? FromLocation { get; set; }
    public Location? ToLocation { get; set; }
    public TimeWindow? PickupWindow { get; set; }
    public TimeWindow? DropoffWindow { get; set; }
    public string? Requirements { get; set; }
    public DeliveryStatus Status { get; set; } = DeliveryStatus.Created;
    public string? Notes { get; set; }
    public DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? PickedUpAt { get; set; }
    public DateTimeOffset? DeliveredAt { get; set; }
    public List<DeliveryLeg> Legs { get; set; } = new();
}

public sealed class DeliveryLeg
{
    public int Index { get; set; }
    public Location? FromLocation { get; set; }
    public Location? ToLocation { get; set; }
    public DeliveryStatus Status { get; set; } = DeliveryStatus.Created;
    public DateTimeOffset? PickupTime { get; set; }
    public DateTimeOffset? DropoffTime { get; set; }
}
