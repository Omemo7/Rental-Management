using System;
using System.Collections.Generic;

namespace Rental_Management.DataAccess.Entities;

public partial class CarsRental
{
    public int Id { get; set; }

    public int RentalId { get; set; }

    public int CarId { get; set; }

    public int TenantId { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Rental Rental { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;
}
