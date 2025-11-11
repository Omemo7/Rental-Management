using RentalManagement.Business.Domain.ValueObjects;

namespace Business.Application.Payments.Commands
{
    public class UpdatePaymentCommand
    {
        public Guid Id { get; private set; }
        public DateTime PaidAt { get; private set; }
        public Money Amount { get; private set; }
        public string Method { get; private set; }   // Cash, Transfer, Card, etc.
        public string? Notes { get; private set; }

        public UpdatePaymentCommand(Guid id,  DateTime paidAt, Money amount, string method, string? notes = null)
        {
            Id = id;
            
            PaidAt = paidAt;
            Amount = amount;
            Method = method;
            Notes = notes;
        }

       
    }
}