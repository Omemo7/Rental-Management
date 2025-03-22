using System;
using System.Collections.Generic;

namespace Rental_Management.DataAccess.Entities;

public partial class ApartmentsRental
{
    public int Id { get; set; }

    public int ApartmentId { get; set; }

    public int RentalId { get; set; }

    public int TenantId { get; set; }

    public virtual Apartment Apartment { get; set; } = null!;

    public virtual Rental Rental { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;
}
