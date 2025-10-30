// .../Configurations/MaintenanceRequestConfig.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalManagement.Business.Domain.Entities;

namespace RentalManagement.Infrastructure.Persistence.Configurations;

public sealed class MaintenanceRequestConfig : IEntityTypeConfiguration<MaintenanceRequest>
{
    public void Configure(EntityTypeBuilder<MaintenanceRequest> e)
    {
        e.ToTable("MaintenanceRequests");
        e.HasKey(x => x.Id);

        e.Property(x => x.Category).IsRequired().HasMaxLength(100);
        e.Property(x => x.Description).IsRequired().HasMaxLength(1000);

        e.Property(x => x.Priority).IsRequired();
        e.Property(x => x.Status).IsRequired();

        e.Property(x => x.CreatedAt).IsRequired();
        e.Property(x => x.ScheduledAt);
        e.Property(x => x.CompletedAt);

        e.Property(x => x.LaborCost).HasPrecision(18, 2);
        e.Property(x => x.PartsCost).HasPrecision(18, 2);
        e.Property(x => x.Currency).HasMaxLength(3).IsFixedLength();
        e.Property(x => x.BillToTenant).IsRequired();

        e.HasIndex(x => new { x.ApartmentId, x.Status });
        e.HasIndex(x => x.CreatedAt);

        e.Property(x => x.RowVersion).IsRowVersion().IsConcurrencyToken();
    }
}
