using RentalManagement.Business.Domain.ValueObjects;

namespace Business.Application.Payments.Summaries
{
    public class PaymentSummary
    {
        public Guid Id { get; private set; }
        public Guid LeaseId { get; private set; }
        public DateTime PaidAt { get; private set; }
        public Money Amount { get; private set; }
        public string Method { get; private set; }   // Cash, Transfer, Card, etc.
        public string? Notes { get; private set; }

        public static PaymentSummary FromPayment(RentalManagement.Business.Domain.Entities.Payment payment)
        {
            return new PaymentSummary
            {
                Id = payment.Id,
                LeaseId = payment.LeaseId,
                PaidAt = payment.PaidAt,
                Amount = payment.Amount,
                Method = payment.Method,
                Notes = payment.Notes
            };
        }
    }
}