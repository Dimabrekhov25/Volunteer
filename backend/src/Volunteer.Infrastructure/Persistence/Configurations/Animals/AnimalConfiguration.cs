using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volunteer.Domain.Entities.Animals;

namespace Volunteer.Infrastructure.Persistence.Configurations.Animals;

public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
        builder.ToTable("Animals");
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Species)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Breed)
            .HasMaxLength(100);

        builder.Property(p => p.Color)
            .HasMaxLength(50);

        builder.Property(p => p.MicrochipId)
            .HasMaxLength(100);

        builder.Property(p => p.Status)
            .IsRequired();

        builder.HasOne(p => p.AdopterProfile)
            .WithMany(p => p.Animals)
            .HasForeignKey(p => p.AdopterProfileId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(p => p.Photos)
            .WithOne()
            .HasForeignKey("AnimalId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Documents)
            .WithOne()
            .HasForeignKey("AnimalId")
            .OnDelete(DeleteBehavior.Cascade);

        builder.OwnsOne(p => p.CurrentLocation);
    }
}
