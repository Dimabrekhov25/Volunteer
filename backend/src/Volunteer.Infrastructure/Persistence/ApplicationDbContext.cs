using Microsoft.EntityFrameworkCore;
using Volunteer.Application.Common.Interfaces;
using Volunteer.Domain.Entities;
using Volunteer.Domain.Entities.Animals;
using Volunteer.Domain.Entities.Deliveries;
using Volunteer.Domain.Entities.Documents;
using Volunteer.Domain.Entities.Organizations;
using Volunteer.Domain.Entities.Profiles;
using Volunteer.Domain.Entities.Users;

namespace Volunteer.Infrastructure.Persistence;

public sealed class ApplicationDbContext : DbContext,IUnitOfWork
{
   public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
   {
   }

   public DbSet<User> Users => Set<User>();
   public DbSet<Animal> Animals => Set<Animal>();
   public DbSet<AnimalPhoto> AnimalPhotos => Set<AnimalPhoto>();
   public DbSet<Document> Documents => Set<Document>();
   public DbSet<Organization> Organizations => Set<Organization>();
   public DbSet<AdopterProfile> AdopterProfiles => Set<AdopterProfile>();
   public DbSet<VolunteerProfile> VolunteerProfiles => Set<VolunteerProfile>();
   public DbSet<Delivery> Deliveries => Set<Delivery>();
   public DbSet<DeliveryLeg> DeliveryLegs => Set<DeliveryLeg>();
   public DbSet<DeliveryAnimal> DeliveryAnimals => Set<DeliveryAnimal>();

   public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
   {
      HandleSoftDelete();
      return base.SaveChangesAsync(cancellationToken);
   }

   public void HandleSoftDelete()
   {
      var entries = ChangeTracker
         .Entries()  
         .Where(e => e.State == EntityState.Deleted && e.Entity is BaseEntity);
      foreach (var entry in entries)
      {
         var entity = (BaseEntity)entry.Entity;
         entry.State = EntityState.Modified;
         entity.IsDeleted = true;
         entity.UpdatedAt =  DateTime.UtcNow;
      }
   }
   
   protected override void OnModelCreating(ModelBuilder modelBuilder)
   { 
      base.OnModelCreating(modelBuilder);
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
   }
}
