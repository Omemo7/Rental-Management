// RentalManagement.Infrastructure/Persistence/Configurations/_Common.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentalManagement.Business.Domain.ValueObjects;

namespace RentalManagement.Infrastructure.Persistence.Configurations;

public static class MappingHelpers
{
    public static void MapMoney<T>(OwnedNavigationBuilder<T, Money> m) where T : class
    {
        m.Property(p => p.Amount).HasPrecision(18, 2);
        m.Property(p => p.Currency).HasMaxLength(3).IsFixedLength();
    }

    // If you use DateOnly in domain (EF Core 8+)
    public static void ConfigureDateOnly(PropertyBuilder<DateOnly> p)
        => p.HasConversion(
            v => v.ToDateTime(TimeOnly.MinValue),
            v => DateOnly.FromDateTime(v));

    public static void ConfigureNullableDateOnly(PropertyBuilder<DateOnly?> p)
        => p.HasConversion(
            v => v.HasValue ? v.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null,
            v => v.HasValue ? DateOnly.FromDateTime(v.Value) : (DateOnly?)null);
}
