using System;
using System.Collections.Generic;

namespace Rental_Management.DataAccess.Entities;

public partial class Apartment
{
    public int Id { get; set; }

    public string StreetAddress { get; set; } = null!;

    public string Neighborhood { get; set; } = null!;

    public string City { get; set; } = null!;

    public string FloorNumber { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string BuildingNumber { get; set; } = null!;

    public decimal SquaredMeters { get; set; }

    public int LandLordId { get; set; }

    public virtual ICollection<ApartmentsRental> ApartmentsRentals { get; set; } = new List<ApartmentsRental>();

    public virtual Landlord LandLord { get; set; } = null!;
}
