using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Volunteer.Domain.Entities;

namespace Volunteer.Infrastructure.Persistence;

public sealed class ApplicationDbContext(IConfiguration configuration) : DbContext
{
   
   
   public DbSet<Users> Users => Set<Users>();

   
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      optionsBuilder.UseNpgsql(configuration.GetConnectionString("Database"));
      optionsBuilder.UseSnakeCaseNamingConvention();
      optionsBuilder.UseLoggerFactory(CreateLoggerFactory( ));
      
   }
   
   private ILoggerFactory CreateLoggerFactory()=> LoggerFactory.Create(builder => {builder.AddConsole();});
}
