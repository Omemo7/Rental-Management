using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.DTOs.Payment
{
    public class AddPaymentDTO
    {
     
        public DateOnly PaymentDate { get; set; }

        public decimal PaidAmount { get; set; }

        public int RentalId { get; set; }
    }
}
