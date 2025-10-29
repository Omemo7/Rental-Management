// .../Configurations/LandlordConfig.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalManagement.Business.Domain.Entities;

namespace RentalManagement.Infrastructure.Persistence.Configurations;

public sealed class LandlordConfig : IEntityTypeConfiguration<Landlord>
{
    public void Configure(EntityTypeBuilder<Landlord> e)
    {
        e.ToTable("Landlords");
        e.HasKey(x => x.Id);

        e.Property(x => x.FullName).IsRequired().HasMaxLength(200);
        e.Property(x => x.Email).HasMaxLength(200);
        e.Property(x => x.PhoneNumber).HasMaxLength(50);
        e.Property(x => x.IsActive).IsRequired();

        // If you linked to Identity:
        e.Property("UserId").IsRequired();
        e.HasIndex("UserId").IsUnique();

        e.Property(x => x.RowVersion).IsRowVersion().IsConcurrencyToken();
    }
}
