// .../Configurations/TenantConfig.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalManagement.Business.Domain.Entities;

namespace RentalManagement.Infrastructure.Persistence.Configurations;

public sealed class TenantConfig : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> e)
    {
        e.ToTable("Tenants");
        e.HasKey(x => x.Id);

        e.Property(x => x.FullName).IsRequired().HasMaxLength(200);
        e.Property(x => x.Email).HasMaxLength(200);
        e.Property(x => x.PhoneNumber).HasMaxLength(50);

        e.Property(x => x.RowVersion).IsRowVersion().IsConcurrencyToken();
    }
}
