using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volunteer.Domain.Entities.Profiles;

namespace Volunteer.Infrastructure.Persistence.Configurations.Profiles;

public sealed class VolunteerProfileConfiguration : IEntityTypeConfiguration<VolunteerProfile>
{
    public void Configure(EntityTypeBuilder<VolunteerProfile> builder)
    {
        builder.ToTable("volunteer_profiles");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.VerificationStatus)
            .IsRequired();

        builder.Property(p => p.AvailabilityStatus)
            .IsRequired();

        builder.Property(p => p.SpeciesAllowed)
            .HasColumnType("text[]")
            .IsRequired();

        builder.OwnsOne(p => p.HomeBaseLocation);
        builder.OwnsOne(p => p.EmergencyContact);

        builder.HasOne(p => p.User)
            .WithOne()
            .HasForeignKey<VolunteerProfile>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
