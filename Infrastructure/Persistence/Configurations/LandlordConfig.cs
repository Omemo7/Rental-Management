// .../Configurations/LandlordConfig.cs
using Infrastructure.Identity;
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

        e.HasOne<ApplicationUser>()                 // no nav in domain
         .WithOne()
         .HasForeignKey<Landlord>(l => l.Id)       // **shared primary key**
         .OnDelete(DeleteBehavior.Restrict);       // be safe

        e.HasMany<Apartment>()                  // no nav in domain
         .WithOne()
         .HasForeignKey(a => a.LandlordId)
         .OnDelete(DeleteBehavior.Cascade);     

        e.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
        e.Property(x => x.LastName).IsRequired().HasMaxLength(100);




        e.Property(x => x.RowVersion).IsRowVersion().IsConcurrencyToken();
    }
}
