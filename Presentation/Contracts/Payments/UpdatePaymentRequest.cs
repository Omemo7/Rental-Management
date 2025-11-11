using Business.Application.Payments.Commands;
using RentalManagement.Business.Domain.ValueObjects;

namespace Presentation.Contracts.Payments
{
    public class UpdatePaymentRequest
    {
        
        public DateTime PaidAt { get; set; }
        public Money Amount { get; set; }
        public string Method { get;  set; }   
        public string? Notes { get; set; }

        public UpdatePaymentCommand ToCommand(Guid id)
        {
            return new UpdatePaymentCommand(
                id,
                PaidAt,
                Amount,
                Method,
                Notes
            );
        }
    }
}