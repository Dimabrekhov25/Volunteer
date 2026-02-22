using Volunteer.Domain.Entities.Animals;

namespace Volunteer.Domain.Entities.Deliveries;

public class DeliveryAnimal
{
    public Guid DeliveryId { get; set; }
    public Delivery Delivery { get; set; } = null!;

    public Guid AnimalId { get; set; }
    public Animal Animal { get; set; } = null!;

   
}