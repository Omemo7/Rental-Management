using System;
using System.Collections.Generic;

namespace Rental_Management.DataAccess.Entities;

public partial class Person
{
    public int Id { get; set; }

    public string NationalNumber { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string Email { get; set; } = null!;

    public virtual Landlord? Landlord { get; set; }

    public virtual ICollection<Phone> Phones { get; set; } = new List<Phone>();

    public virtual Tenant? Tenant { get; set; }
}
