using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Rental_Management.DataAccess.Entities;

namespace Rental_Management.DataAccess;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Maintenance> Maintenances { get; set; } 
    public virtual DbSet<RentPaymentFrequency> RentPaymentFrequency { get; set; }
    public virtual DbSet<Apartment> Apartments { get; set; }

    public virtual DbSet<ApartmentsRental> ApartmentsRentals { get; set; }

    public virtual DbSet<ApartmentBuilding> ApartmentBuildings { get; set; }
    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarsRental> CarsRentals { get; set; }

    public virtual DbSet<CustomItem> CustomItems { get; set; }

    public virtual DbSet<CustomItemType> CustomItemTypes { get; set; }

    public virtual DbSet<CustomRental> CustomRentals { get; set; }

    public virtual DbSet<Landlord> Landlords { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<TenantPhone> TenantsPhones { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<Tenant> Tenants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-SE57QM8;Database=Rental_Management;Trusted_Connection=True;TrustServerCertificate=True;");
    }

       
  

}
