// .../Configurations/ApartmentConfig.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalManagement.Business.Domain.Entities;

namespace RentalManagement.Infrastructure.Persistence.Configurations;

public sealed class ApartmentConfig : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> e)
    {
        e.ToTable("Apartments");
        e.HasKey(x => x.Id);

        e.Property(x => x.UnitNumber).IsRequired().HasMaxLength(20);
        e.Property(x => x.Bedrooms).IsRequired();
        e.Property(x => x.Bathrooms).IsRequired();
        e.Property(x => x.AreaSqm).HasPrecision(18, 2);

        // FKs (no domain navigations required)
        e.HasIndex(x => new { x.BuildingId, x.UnitNumber }).IsUnique();
        e.HasIndex(x => x.LandlordId);

        e.Property(x => x.RowVersion).IsRowVersion().IsConcurrencyToken();
    }
}
