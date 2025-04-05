using System;
using System.Collections.Generic;

namespace Rental_Management.DataAccess.Entities;

public partial class Car
{
    public int Id { get; set; }

    public string Model { get; set; } = null!;

    public string Color { get; set; } = null!;
    public bool Vacant { get; set; }

    public string RegistrationPlate { get; set; } = null!;

    public string Make { get; set; } = null!;

    public int LandLordId { get; set; }

    public virtual ICollection<CarsRental> CarsRentals { get; set; } = new List<CarsRental>();

    public virtual Landlord LandLord { get; set; } = null!;
}
