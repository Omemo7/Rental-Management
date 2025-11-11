using RentalManagement.Business.Domain.ValueObjects;

namespace Business.Application.Payments.Commands
{
    public class AddPaymentCommand
    {
        public Guid Id { get; private set; }
        public Guid LeaseId { get; private set; }
        public DateTime PaidAt { get; private set; }
        public Money Amount { get; private set; }
        public string Method { get; private set; }   // Cash, Transfer, Card, etc.
        public string? Notes { get; private set; }
        
        public AddPaymentCommand(Guid leaseId,  Money amount, string method, string? notes = null)
        {
            
            LeaseId = leaseId;
            PaidAt = DateTime.Now;
            Amount = amount;
            Method = method;
            Notes = notes;
        }
        public RentalManagement.Business.Domain.Entities.Payment ToEntity()
        {
            return new RentalManagement.Business.Domain.Entities.Payment(
                Guid.NewGuid(),
                LeaseId,
                PaidAt,
                Amount,
                Method,
                Notes
            );
        }
    }
}