using System;
using System.Collections.Generic;

namespace Rental_Management.DataAccess.Entities;

public partial class CustomRental
{
    public int Id { get; set; }

    public int RentalId { get; set; }

    public int CustomItemId { get; set; }

    public int TenantId { get; set; }

    public virtual CustomItem CustomItem { get; set; } = null!;

    public virtual Rental Rental { get; set; } = null!;

    public virtual Tenant Tenant { get; set; } = null!;
}
