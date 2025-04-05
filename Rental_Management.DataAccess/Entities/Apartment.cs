using System;
using System.Collections.Generic;
using System.Data;

namespace Rental_Management.DataAccess.Entities;

public partial class Apartment
{
    public int Id { get; set; }
    public int FloorNumber { get; set; }

    public int NumberOfRooms { get; set; }
    public int NumberOfBathrooms { get; set; }

    public bool Vacant { get; set; }
    public decimal SquaredMeters { get; set; }

    public int ApartmentBuildingId { get; set; }


    public virtual ICollection<ApartmentsRental> ApartmentsRentals { get; set; } = new List<ApartmentsRental>();
    public virtual ApartmentBuilding ApartmentBuilding { get; set; } = null!;
   
}
