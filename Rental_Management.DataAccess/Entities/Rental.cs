using System;
using System.Collections.Generic;

namespace Rental_Management.DataAccess.Entities;

public partial class Rental
{
    public int Id { get; set; }

    public string Contract { get; set; } = null!;

    public decimal RentValue { get; set; }

    public string RentPaymentFrequency { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }
    public int TenantId { get; set; }
    public virtual Tenant Tenant { get; set; } = null!;

    public virtual ICollection<ApartmentsRental> ApartmentsRentals { get; set; } = new List<ApartmentsRental>();

    public virtual ICollection<CarsRental> CarsRentals { get; set; } = new List<CarsRental>();

    public virtual ICollection<CustomRental> CustomRentals { get; set; } = new List<CustomRental>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
