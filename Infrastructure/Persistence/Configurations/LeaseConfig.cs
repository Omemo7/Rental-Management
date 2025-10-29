// .../Configurations/LeaseConfig.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalManagement.Business.Domain.Entities;
using RentalManagement.Infrastructure.Persistence.Configurations;

namespace RentalManagement.Infrastructure.Persistence.Configurations;

public sealed class LeaseConfig : IEntityTypeConfiguration<Lease>
{
    public void Configure(EntityTypeBuilder<Lease> e)
    {
        e.ToTable("Leases");
        e.HasKey(x => x.Id);

        // If you used DateOnly in the entity:
        // MappingHelpers.ConfigureDateOnly(e.Property(x => x.StartDate));
        // MappingHelpers.ConfigureNullableDateOnly(e.Property(x => x.EndDate));

        // If you used DateTime(Utc) instead, just ensure it's required where needed:
        e.Property(x=>x.StartDate).IsRequired();

        e.OwnsOne(x => x.MonthlyRent, MappingHelpers.MapMoney);
        e.OwnsOne(x => x.SecurityDeposit, MappingHelpers.MapMoney);

        e.Property(x => x.RowVersion).IsRowVersion().IsConcurrencyToken();

        e.HasIndex(x => new { x.ApartmentId, x.EndDate }); // support queries

        // Filtered unique index: at most one active lease per apartment
        // Must be created in a migration for SQL Server. Example:
        // migrationBuilder.Sql("""
        // CREATE UNIQUE INDEX UX_Leases_Apartment_Active
        // ON Leases (ApartmentId)
        // WHERE EndDateUtc IS NULL;
        // """);
    }
}
