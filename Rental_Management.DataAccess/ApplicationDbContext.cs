using System;
using System.Collections.Generic;
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

    public virtual DbSet<Apartment> Apartments { get; set; }

    public virtual DbSet<ApartmentsRental> ApartmentsRentals { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarsRental> CarsRentals { get; set; }

    public virtual DbSet<CustomItem> CustomItems { get; set; }

    public virtual DbSet<CustomItemType> CustomItemTypes { get; set; }

    public virtual DbSet<CustomRental> CustomRentals { get; set; }

    public virtual DbSet<Landlord> Landlords { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<Tenant> Tenants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=DESKTOP-SE57QM8;Database=Rental_Management;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Apartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Apartmen__3214EC07F8E63B05");

            entity.Property(e => e.BuildingNumber).HasMaxLength(50);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.FloorNumber).HasMaxLength(10);
            entity.Property(e => e.Neighborhood).HasMaxLength(100);
            entity.Property(e => e.SquaredMeters).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.StreetAddress).HasMaxLength(255);
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.LandLord).WithMany(p => p.Apartments)
                .HasForeignKey(d => d.LandLordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Apartments_Landlords");
        });

        modelBuilder.Entity<ApartmentsRental>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Apartmen__3214EC07B4640AEA");

            entity.ToTable("ApartmentsRental");

            entity.HasOne(d => d.Apartment).WithMany(p => p.ApartmentsRentals)
                .HasForeignKey(d => d.ApartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApartmentsRental_Apartments");

            entity.HasOne(d => d.Rental).WithMany(p => p.ApartmentsRentals)
                .HasForeignKey(d => d.RentalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApartmentsRental_Rental");

            entity.HasOne(d => d.Tenant).WithMany(p => p.ApartmentsRentals)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApartmentsRental_Tenants");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cars__3214EC0751ECB10B");

            entity.HasIndex(e => e.RegistrationPlate, "UQ__Cars__808BBC878715B068").IsUnique();

            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.Make).HasMaxLength(100);
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.RegistrationPlate).HasMaxLength(50);

            entity.HasOne(d => d.LandLord).WithMany(p => p.Cars)
                .HasForeignKey(d => d.LandLordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cars_Landlords");
        });

        modelBuilder.Entity<CarsRental>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CarsRent__3214EC07509CC1C6");

            entity.ToTable("CarsRental");

            entity.HasOne(d => d.Car).WithMany(p => p.CarsRentals)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarsRental_Cars");

            entity.HasOne(d => d.Rental).WithMany(p => p.CarsRentals)
                .HasForeignKey(d => d.RentalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarsRental_Rental");

            entity.HasOne(d => d.Tenant).WithMany(p => p.CarsRentals)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarsRental_Tenants");
        });

        modelBuilder.Entity<CustomItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CustomIt__3214EC07CFB34A9D");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.CustomItemType).WithMany(p => p.CustomItems)
                .HasForeignKey(d => d.CustomItemTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomItems_CustomItemTypes");

            entity.HasOne(d => d.LandLord).WithMany(p => p.CustomItems)
                .HasForeignKey(d => d.LandLordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomItems_Landlords");
        });

        modelBuilder.Entity<CustomItemType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CustomIt__3214EC074C5141F9");

            entity.Property(e => e.Type).HasMaxLength(100);

            entity.HasOne(d => d.LandLord).WithMany(p => p.CustomItemTypes)
                .HasForeignKey(d => d.LandLordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomItemTypes_Landlords");
        });

        modelBuilder.Entity<CustomRental>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CustomRe__3214EC07056E6677");

            entity.ToTable("CustomRental");

            entity.HasOne(d => d.CustomItem).WithMany(p => p.CustomRentals)
                .HasForeignKey(d => d.CustomItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomRental_CustomItems");

            entity.HasOne(d => d.Rental).WithMany(p => p.CustomRentals)
                .HasForeignKey(d => d.RentalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomRental_Rental");

            entity.HasOne(d => d.Tenant).WithMany(p => p.CustomRentals)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomRental_Tenants");
        });

        modelBuilder.Entity<Landlord>(entity =>
        {
            entity.HasIndex(e => e.Username).IsUnique();
            entity.HasKey(e => e.Id).HasName("PK__Landlord__3214EC07DA20C497");

            entity.HasIndex(e => e.PersonId, "UQ__Landlord__AA2FFBE4C2545929").IsUnique();

            entity.HasOne(d => d.Person).WithOne(p => p.Landlord)
                .HasForeignKey<Landlord>(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Landlords_People");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payments__3214EC07F323E055");

            entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Rental).WithMany(p => p.Payments)
                .HasForeignKey(d => d.RentalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payments_Rental");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__People__3214EC07E83BA829");

            entity.HasIndex(e => e.Email, "UQ__People__A9D10534AD779934").IsUnique();

            entity.HasIndex(e => e.NationalNumber, "UQ__People__FEA173C223F8E2CE").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.NationalNumber).HasMaxLength(50);
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Phones__3214EC0762C0D826");

            entity.Property(e => e.Phone1)
                .HasMaxLength(50)
                .HasColumnName("Phone");

            entity.HasOne(d => d.Person).WithMany(p => p.Phones)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Phones_People");
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rental__3214EC07D5158E43");

            entity.ToTable("Rental");

            entity.Property(e => e.Contract).HasMaxLength(255);
            entity.Property(e => e.RentPaymentFrequency).HasMaxLength(100);
            entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tenants__3214EC07ECF2AB13");

            entity.HasIndex(e => e.PersonId, "UQ__Tenants__AA2FFBE43D2D3932").IsUnique();

            entity.HasOne(d => d.Person).WithOne(p => p.Tenant)
                .HasForeignKey<Tenant>(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tenants_People");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
