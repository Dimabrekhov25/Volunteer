using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volunteer.Domain.Entities.Documents;

namespace Volunteer.Infrastructure.Persistence.Configurations.Documents;

public sealed class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.ToTable("documents");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Type)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Number)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.FileUrl)
            .IsRequired()
            .HasMaxLength(1024);
    }
}
