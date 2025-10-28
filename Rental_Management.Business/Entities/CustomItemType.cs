using System;
using System.Collections.Generic;

namespace Rental_Management.Business.Entities;

public partial class CustomItemType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public int LandLordId { get; set; }

    public virtual ICollection<CustomItem> CustomItems { get; set; } = new List<CustomItem>();

    public virtual Landlord LandLord { get; set; } = null!;
}
