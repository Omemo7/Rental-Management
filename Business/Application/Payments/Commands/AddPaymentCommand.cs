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
        
        public AddPaymentCommand(Guid id, Guid leaseId, DateTime paidAt, Money amount, string method, string? notes = null)
        {
            Id = id;
            LeaseId = leaseId;
            PaidAt = paidAt;
            Amount = amount;
            Method = method;
            Notes = notes;
        }
        public RentalManagement.Business.Domain.Entities.Payment ToEntity()
        {
            return new RentalManagement.Business.Domain.Entities.Payment(
                Id,
                LeaseId,
                PaidAt,
                Amount,
                Method,
                Notes
            );
        }
    }
}