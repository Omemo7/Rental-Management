using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;

namespace Rental_Management.DataAccess.Entities;

public partial class Landlord
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public ICollection<Tenant> Tenants { get; set; }=null!;

    public virtual ICollection<Apartment> Apartments { get; set; } = new List<Apartment>();

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual ICollection<CustomItemType> CustomItemTypes { get; set; } = new List<CustomItemType>();

    public virtual ICollection<CustomItem> CustomItems { get; set; } = new List<CustomItem>();

}
