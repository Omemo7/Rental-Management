using Azure.Identity;
using System;
using System.Collections.Generic;

namespace Rental_Management.DataAccess.Entities;

public partial class Tenant
{
    public int Id { get; set; }

    public string NationalNumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;
    public int LandlordId { get; set; }

    public virtual ICollection<TenantPhone> Phones { get; set; } = new List<TenantPhone>();

  
    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
    public virtual Landlord Landlord { get; set; }=null!;
    
}
