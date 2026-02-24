using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Volunteer.Application.Common.Interfaces;
using Volunteer.Infrastructure.Persistence;
using Volunteer.Infrastructure.Repositories;

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

        builder.Services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
        builder.Services.AddScoped<IUsersRepositories, UserRepositories>();
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
