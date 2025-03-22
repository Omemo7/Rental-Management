using System;
using System.Collections.Generic;

namespace Rental_Management.DataAccess.Entities;

public partial class Payment
{
    public int Id { get; set; }

    public DateOnly PaymentDate { get; set; }

    public decimal PaidAmount { get; set; }

    public int RentalId { get; set; }

    public virtual Rental Rental { get; set; } = null!;
}
