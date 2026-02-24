using CSharpFunctionalExtensions;
using Volunteer.Domain.Entities;
using Volunteer.Domain.Enums;
using Volunteer.Domain.ValueObjects;

namespace Volunteer.Domain.Entities.Deliveries;

public sealed class Delivery : BaseEntity
{

    private Delivery(string requirements, string notes)
    {
        Requirements = requirements;
        Notes = notes;
    }
        
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
    public List<DeliveryAnimal> DeliveryAnimals { get; set; } = new();
    public DateTimeOffset? PickedUpAt { get; set; }
    public DateTimeOffset? DeliveredAt { get; set; }
    public List<DeliveryLeg> Legs { get; set; } = new();

    public static Result<Delivery, string> Create(string requirements, string notes)
    {
        if (string.IsNullOrWhiteSpace(requirements))
        {
            return Result.Failure<Delivery,string>("requirements cannot be empty");
        }
        if (string.IsNullOrWhiteSpace(notes))
        {
            return Result.Failure<Delivery,string>("notes cannot be empty");
        }

        var Delivery = new Delivery(requirements, notes);
        return Result.Success<Delivery,string>(Delivery);
    }
    
}
