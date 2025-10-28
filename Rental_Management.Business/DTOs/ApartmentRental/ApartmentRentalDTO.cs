using Rental_Management.Business.DTOs.Rental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.DTOs.ApartmentRental
{
    public class ApartmentRentalDTO
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public RentalDTO Rental { get; set; } = null!;
    }
}
