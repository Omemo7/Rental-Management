using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Entities
{
    public class RentPaymentFrequency
    {
        public int Id { get; set; }
        public string Frequency { get; set; } = null!;
        public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    }
}
