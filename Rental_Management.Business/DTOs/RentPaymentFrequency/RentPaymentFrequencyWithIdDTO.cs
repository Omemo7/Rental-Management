using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.DTOs.RentPaymentFrequency
{
    public class RentPaymentFrequencyWithIdDTO
    {
        public int Id { get; set; }
        public string Frequency { get; set; } = null!;
        
    }
}
