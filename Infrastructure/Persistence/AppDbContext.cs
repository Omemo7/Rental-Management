// RentalManagement.Infrastructure/Persistence/AppDbContext.cs
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentalManagement.Business.Domain.Entities;
using RentalManagement.Infrastructure.Persistence.Configurations;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RentalManagement.Infrastructure.Persistence;

public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Building> Buildings => Set<Building>();
    public DbSet<Apartment> Apartments => Set<Apartment>();
    public DbSet<Lease> Leases => Set<Lease>();
    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<Landlord> Landlords => Set<Landlord>();
    public DbSet<MaintenanceRequest> MaintenanceRequests => Set<MaintenanceRequest>();
    public DbSet<Payment> Payments => Set<Payment>(); 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        modelBuilder.ApplyConfiguration(new LandlordConfig());
    }
      
}
