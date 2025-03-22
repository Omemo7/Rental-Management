using System;
using System.Collections.Generic;

namespace Rental_Management.DataAccess.Entities;

public partial class Tenant
{
    public int Id { get; set; }

    public int PersonId { get; set; }

    public virtual ICollection<ApartmentsRental> ApartmentsRentals { get; set; } = new List<ApartmentsRental>();

    public virtual ICollection<CarsRental> CarsRentals { get; set; } = new List<CarsRental>();

    public virtual ICollection<CustomRental> CustomRentals { get; set; } = new List<CustomRental>();

    public virtual Person Person { get; set; } = null!;
}
