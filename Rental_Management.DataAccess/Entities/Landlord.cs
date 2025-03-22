using System;
using System.Collections.Generic;

namespace Rental_Management.DataAccess.Entities;

public partial class Landlord
{
    public int Id { get; set; }

    public int PersonId { get; set; }

    public virtual ICollection<Apartment> Apartments { get; set; } = new List<Apartment>();

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual ICollection<CustomItemType> CustomItemTypes { get; set; } = new List<CustomItemType>();

    public virtual ICollection<CustomItem> CustomItems { get; set; } = new List<CustomItem>();

    public virtual Person Person { get; set; } = null!;
}
