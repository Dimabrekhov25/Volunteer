using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volunteer.Domain.Entities.Deliveries;

namespace Volunteer.Infrastructure.Persistence.Configurations.Deliveries;

public sealed class DeliveryAnimalConfiguration : IEntityTypeConfiguration<DeliveryAnimal>
{
    public void Configure(EntityTypeBuilder<DeliveryAnimal> builder)
    {
        builder.ToTable("delivery_animals");

        builder.HasKey(p => new { p.DeliveryId, p.AnimalId });

        builder.HasOne(p => p.Delivery)
            .WithMany(p => p.DeliveryAnimals)
            .HasForeignKey(p => p.DeliveryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Animal)
            .WithMany(p => p.DeliveryAnimals)
            .HasForeignKey(p => p.AnimalId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
