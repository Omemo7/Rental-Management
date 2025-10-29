// .../Configurations/BuildingConfig.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalManagement.Business.Domain.Entities;
using RentalManagement.Business.Domain.ValueObjects;

namespace RentalManagement.Infrastructure.Persistence.Configurations;

public sealed class BuildingConfig : IEntityTypeConfiguration<Building>
{
    public void Configure(EntityTypeBuilder<Building> e)
    {
        e.ToTable("Buildings");
        e.HasKey(x => x.Id);

        e.Property(x => x.Name).IsRequired().HasMaxLength(200);

        e.OwnsOne(x => x.Address, a =>
        {
            a.Property(p => p.Line1).HasMaxLength(200).IsRequired();
            a.Property(p => p.Line2).HasMaxLength(200);
            a.Property(p => p.City).HasMaxLength(100).IsRequired();
            a.Property(p => p.Country).HasMaxLength(100).IsRequired();
            a.Property(p => p.PostalCode).HasMaxLength(20);
        });

        e.Property(x => x.RowVersion).IsRowVersion().IsConcurrencyToken();
    }
}
