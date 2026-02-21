using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Volunteer.Infrastructure.Persistence;

namespace Volunteer.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<ApplicationDbContext>("DefaultConnection",
            configureDbContextOptions: options =>
        {
            options.UseSnakeCaseNamingConvention();
        });
    }

    public static IHostApplicationBuilder AddNpgsqlDbContext<TContext>(
        this IHostApplicationBuilder builder,
        string connectionName,
        Action<DbContextOptionsBuilder>? configureDbContextOptions = null)
        where TContext : DbContext
    {
        builder.Services.AddDbContext<TContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString(connectionName));
            configureDbContextOptions?.Invoke(options);
        });

        return builder;
    }
}
