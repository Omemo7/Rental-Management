using System;
using System.Collections.Generic;
using System.Data;

namespace Rental_Management.DataAccess.Entities;

public partial class Apartment
{
    public int Id { get; set; }

   

    public string FloorNumber { get; set; } = null!;

    

    public decimal SquaredMeters { get; set; }

    public int LandLordId { get; set; }

    public int ApartmentBuildingId { get; set; }


    public virtual ICollection<ApartmentsRental> ApartmentsRentals { get; set; } = new List<ApartmentsRental>();
    public virtual ApartmentBuilding ApartmentBuilding { get; set; } = null!;
    public virtual Landlord LandLord { get; set; } = null!;
}
