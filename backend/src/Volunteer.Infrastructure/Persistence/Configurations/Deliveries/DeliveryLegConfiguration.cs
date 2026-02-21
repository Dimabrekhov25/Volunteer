using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volunteer.Domain.Entities.Deliveries;

namespace Volunteer.Infrastructure.Persistence.Configurations.Deliveries;

public sealed class DeliveryLegConfiguration : IEntityTypeConfiguration<DeliveryLeg>
{
    public void Configure(EntityTypeBuilder<DeliveryLeg> builder)
    {
        builder.ToTable("delivery_legs");

        builder.Property<Guid>("DeliveryId");
        builder.HasKey("DeliveryId", "Index");

        builder.Property(p => p.Index)
            .IsRequired();

        builder.Property(p => p.Status)
            .IsRequired();

        builder.OwnsOne(p => p.FromLocation);
        builder.OwnsOne(p => p.ToLocation);
    }
}
