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

    public virtual ICollection<ApartmentsRental> ApartmentsRentals { get; set; } = new List<ApartmentsRental>();

    public virtual ICollection<CarsRental> CarsRentals { get; set; } = new List<CarsRental>();

    public virtual ICollection<CustomRental> CustomRentals { get; set; } = new List<CustomRental>();
    public virtual Landlord Landlord { get; set; }=null!;
    
}
