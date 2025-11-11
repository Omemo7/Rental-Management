using Business.Application.Payments.Commands;
using RentalManagement.Business.Domain.ValueObjects;

namespace Presentation.Contracts.Payments
{
    public class AddPaymentRequest
    {
        public Guid LeaseId { get;  set; }
        public Money Amount { get;  set; }
        public string Method { get;  set; }   // Cash, Transfer, Card, etc.
        public string? Notes { get;  set; }

        public AddPaymentCommand ToCommand()
        {
            return new AddPaymentCommand(
                LeaseId,
                
                Amount,
                Method,
                Notes
            );
        }
    }
}