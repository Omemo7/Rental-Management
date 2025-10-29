// RentalManagement.Infrastructure/Persistence/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using RentalManagement.Business.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RentalManagement.Infrastructure.Persistence;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Building> Buildings => Set<Building>();
    public DbSet<Apartment> Apartments => Set<Apartment>();
    public DbSet<Lease> Leases => Set<Lease>();
    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<Landlord> Landlords => Set<Landlord>();
    public DbSet<MaintenanceRequest> MaintenanceRequests => Set<MaintenanceRequest>();
    public DbSet<Payment> Payments => Set<Payment>(); 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
}
