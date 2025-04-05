using System;
using System.Collections.Generic;

namespace Rental_Management.DataAccess.Entities;

public partial class CarsRental
{
    public int Id { get; set; }

    public int RentalId { get; set; }

    public int CarId { get; set; }

   

    public virtual Car Car { get; set; } = null!;

    public virtual Rental Rental { get; set; } = null!;

    
}
