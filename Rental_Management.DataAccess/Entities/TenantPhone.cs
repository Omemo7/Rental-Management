using System;
using System.Collections.Generic;

namespace Rental_Management.DataAccess.Entities;

public partial class TenantPhone
{
    public int Id { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public int TenantId { get; set; }
    public virtual Tenant Tenant { get; set; } = null!;
}
   
