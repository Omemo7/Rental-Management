using RentalManagement.Business.Domain.ValueObjects;

namespace RentalManagement.Business.Domain.Entities;

public sealed class Payment
{
    public Guid Id { get; private set; }
    public Guid LeaseId { get; private set; }
    public DateTime PaidAt { get; private set; }
    public Money Amount { get; private set; }
    public string Method { get; private set; }   // Cash, Transfer, Card, etc.
    public string? Notes { get; private set; }

    private Payment() { } // EF

    public Payment(Guid id, Guid leaseId, DateTime paidAt, Money amount, string method, string? notes = null)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id required");
        if (leaseId == Guid.Empty) throw new ArgumentException("LeaseId required");
        if (amount.Amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "Must be positive");

        Id = id;
        LeaseId = leaseId;
        PaidAt = paidAt;
        Amount = amount;
        Method = method;
        Notes = notes;
    }
}
