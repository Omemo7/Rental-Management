using System;
using System.Collections.Generic;

namespace Rental_Management.Business.Entities;

public partial class ApartmentsRental
{
    public int Id { get; set; }

    public int ApartmentId { get; set; }

    public int RentalId { get; set; }

    

    public virtual Apartment Apartment { get; set; } = null!;

    public virtual Rental Rental { get; set; } = null!;

    
}
