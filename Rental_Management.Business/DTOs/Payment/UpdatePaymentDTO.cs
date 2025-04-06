using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.DTOs.Payment
{
    public class UpdatePaymentDTO
    {
        public int Id { get; set; }

        public DateOnly PaymentDate { get; set; }

        public decimal PaidAmount { get; set; }

        public int RentalId { get; set; }
    }
}
