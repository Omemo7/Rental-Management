// .../Configurations/PaymentConfig.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalManagement.Business.Domain.Entities;
using RentalManagement.Infrastructure.Persistence.Configurations;

namespace RentalManagement.Infrastructure.Persistence.Configurations;

public sealed class PaymentConfig : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> e)
    {
        e.ToTable("Payments");
        e.HasKey(x => x.Id);

        e.HasIndex(x => x.LeaseId);

        e.Property(x => x.PaidAtUtc).IsRequired();

        e.OwnsOne(x => x.Amount, MappingHelpers.MapMoney);

        e.Property("Method").HasMaxLength(50);
        e.Property("Notes").HasMaxLength(500);
    }
}
