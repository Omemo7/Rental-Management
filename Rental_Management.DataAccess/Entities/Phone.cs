using System;
using System.Collections.Generic;

namespace Rental_Management.DataAccess.Entities;

public partial class Phone
{
    public int Id { get; set; }

    public string Phone1 { get; set; } = null!;

    public int PersonId { get; set; }

    public virtual Person Person { get; set; } = null!;
}
