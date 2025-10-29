// RentalManagement.Infrastructure/DependencyInjection.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentalManagement.Infrastructure.Persistence;

namespace RentalManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var cs = config.GetConnectionString("Default")
                 ?? throw new InvalidOperationException("Missing connection string 'Default'.");

        services.AddDbContext<AppDbContext>(opts =>
            opts.UseSqlServer(cs)); // or UseNpgsql / UseSqlite

        // Register repository implementations, identity services, etc.
        // services.AddScoped<IApartmentRepository, ApartmentRepository>();
        // services.AddScoped<ILeaseRepository, LeaseRepository>();
        // ...

        return services;
    }
}
