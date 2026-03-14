using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volunteer.Domain.Entities.Profiles;

namespace Volunteer.Infrastructure.Persistence.Configurations.Profiles;

public sealed class AdopterProfileConfiguration : IEntityTypeConfiguration<AdopterProfile>
{
    public void Configure(EntityTypeBuilder<AdopterProfile> builder)
    {
        builder.ToTable("adopter_profiles");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.FamilyInfo)
            .HasMaxLength(1000);

        builder.Property(p => p.Experience)
            .HasMaxLength(1000);

        builder.Property(p => p.Availability)
            .HasMaxLength(200);

        builder.Property(p => p.Notes)
            .HasMaxLength(2000);

        builder.OwnsOne(p => p.Address);

        builder.HasOne(p => p.User)
            .WithOne()
            .HasForeignKey<AdopterProfile>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Animals)
            .WithOne(a => a.AdopterProfile)
            .HasForeignKey(a => a.AdopterProfileId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
