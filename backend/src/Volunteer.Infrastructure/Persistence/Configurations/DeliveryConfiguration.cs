using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volunteer.Domain.Entities;

namespace Volunteer.Infrastructure.Persistence.Configurations;

public sealed class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
{
    public void Configure(EntityTypeBuilder<Delivery> builder)
    {
        builder.ToTable("deliveries");

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
    }
}
