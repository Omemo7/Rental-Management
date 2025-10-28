using Rental_Management.Business.DTOs.Payment;
using Rental_Management.Business.Entities;

namespace Rental_Management.Business.Interfaces;

public interface IPaymentService : IService<PaymentDTO, AddPaymentDTO, UpdatePaymentDTO>
{
}
