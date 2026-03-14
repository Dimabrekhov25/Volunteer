using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volunteer.Domain.Entities.Deliveries;

namespace Volunteer.Infrastructure.Persistence.Configurations.Deliveries;

public sealed class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
{
    public void Configure(EntityTypeBuilder<Delivery> builder)
    {
        builder.ToTable("deliveries");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Status)
            .IsRequired();

        builder.Property(p => p.Requirements)
            .HasMaxLength(1000);

        builder.Property(p => p.Notes)
            .HasMaxLength(2000);

        builder.HasMany(p => p.Legs)
            .WithOne()
            .HasForeignKey("DeliveryId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.OwnsOne(x => x.PickupWindow, ow =>
        {
            ow.Property(p => p.From).HasColumnName("pickup_from");
            ow.Property(p => p.To).HasColumnName("pickup_to");
        });

        builder.OwnsOne(x => x.DropoffWindow, ow =>
        {
            ow.Property(p => p.From).HasColumnName("dropoff_from");
            ow.Property(p => p.To).HasColumnName("dropoff_to");
        });

        builder.OwnsOne(x => x.FromLocation);
        builder.OwnsOne(x => x.ToLocation);
    }
}
