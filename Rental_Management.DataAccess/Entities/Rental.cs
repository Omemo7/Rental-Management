using System;
using System.Collections.Generic;

namespace Rental_Management.DataAccess.Entities;


public enum RentPaymentFrequency
{
    Daily,
    Weekly,
    Monthly,
    Yearly

}
public partial class Rental
{
    public int Id { get; set; }

    public string Contract { get; set; } = null!;

    public decimal RentValue { get; set; }

    public DateOnly LastNotificationDate { get; set; }

    public RentPaymentFrequency RentPaymentFrequency { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }
    public int TenantId { get; set; }
   
    public virtual Tenant Tenant { get; set; } = null!;

    public virtual ApartmentsRental? ApartmentRental { get; set; } = null!;

    public virtual CarsRental? CarRental { get; set; } =null!;

    public virtual CustomRental? CustomRental { get; set; } =null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
