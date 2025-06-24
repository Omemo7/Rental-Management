using System;
using System.Collections.Generic;

namespace Rental_Management.DataAccess.Entities;


public partial class Rental
{
    public int Id { get; set; }

    

    public decimal RentValue { get; set; }

    public DateOnly LastNotificationDate { get; set; }

    public int RentPaymentFrequencyId { get; set; }
    public virtual RentPaymentFrequency RentPaymentFrequency { get; set; }=null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }
    public int TenantId { get; set; }
   
    public virtual Tenant Tenant { get; set; } = null!;

    public virtual ApartmentsRental? ApartmentRental { get; set; } = null!;

    public virtual CarsRental? CarRental { get; set; } =null!;

    public virtual CustomRental? CustomRental { get; set; } =null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
