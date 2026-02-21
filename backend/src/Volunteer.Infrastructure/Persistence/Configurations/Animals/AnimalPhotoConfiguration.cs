using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volunteer.Domain.Entities.Animals;

namespace Volunteer.Infrastructure.Persistence.Configurations.Animals;

public class AnimalPhotoConfiguration : IEntityTypeConfiguration<AnimalPhoto>
{
    public void Configure(EntityTypeBuilder<AnimalPhoto> builder)
    {
        builder.ToTable("animal_photos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Path)
            .IsRequired()
            .HasMaxLength(512);
    }
}
