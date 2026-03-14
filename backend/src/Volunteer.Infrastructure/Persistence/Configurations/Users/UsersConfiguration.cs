using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volunteer.Domain.Entities.Users;
using Volunteer.Domain.Enums;

namespace Volunteer.Infrastructure.Persistence.Configurations.Users;

public class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("users");
      builder.HasKey(x => x.Id); 

      builder.Property(x => x.Email)
          .IsRequired()
          .HasMaxLength(256);

      builder.Property(x => x.Phone)
          .IsRequired()
          .HasMaxLength(32);

      builder.Property(x => x.FirstName)
          .IsRequired()
          .HasMaxLength(100);

      builder.Property(x => x.LastName)
          .IsRequired()
          .HasMaxLength(100);

      builder.Property(x => x.Status)
          .IsRequired();

      builder.Property(x => x.Roles)
          .HasColumnType("integer[]")
          .IsRequired();

      builder.Property(x => x.LastLoginAt);
    }
}
