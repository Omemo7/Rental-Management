using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.ApartmentRental
{
    public class ApartmentRentalDTOForTenant
    {
        public int Id { get; set; }
        public int RentalId { get; set; }
        public bool IsActive { get; set; }  
        public int ApartmentId { get; set; }
        public string ApartmentName { get; set; } = null!;
        public decimal RentValue { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public string RentPaymentFrequency { get; set; } = null!;

    }


}
