using Rental_Management.Business.DTOs.Payment;
using Rental_Management.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Interfaces
{
    public interface IPaymentService : IService<PaymentDTO,AddPaymentDTO,UpdatePaymentDTO>
    {
    }
}
