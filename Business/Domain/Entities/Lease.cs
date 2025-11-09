using RentalManagement.Business.Domain.ValueObjects;

namespace RentalManagement.Business.Domain.Entities;

public enum RentPaymentFrequency
{
    Daily,
    Weekly,
    Monthly,
    Quarterly,
    Yearly
}
public sealed class Lease
{
    public Guid Id { get; private set; }
    public Guid ApartmentId { get; private set; }
    public Guid TenantId { get; private set; }

    public DateOnly StartDate { get; private set; }
    public DateOnly? EndDate { get; private set; }
    public RentPaymentFrequency PaymentFrequency { get; private set; } 
    public Money RentAmount { get; private set; }
    public Money? SecurityDeposit { get; private set; }

    // Optimistic concurrency (map in EF Fluent config)
    public byte[] RowVersion { get; private set; } = Array.Empty<byte>();

    private Lease() { } // EF

    public Lease(Guid id, Guid apartmentId, Guid tenantId, DateOnly startDate, Money RentAmount, Money? securityDeposit = null,RentPaymentFrequency paymentFrequency=RentPaymentFrequency.Monthly,DateOnly? endDate=null)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id required.", nameof(id));
        if (apartmentId == Guid.Empty) throw new ArgumentException("ApartmentId required.", nameof(apartmentId));
        if (tenantId == Guid.Empty) throw new ArgumentException("TenantId required.", nameof(tenantId));
        if (RentAmount is null || RentAmount.Amount <= 0) throw new ArgumentOutOfRangeException(nameof(RentAmount));
        if(endDate is not null && endDate < startDate) throw new ArgumentException("EndDate cannot be before StartDate.", nameof(endDate));
        if (securityDeposit is { Amount: < 0 }) throw new ArgumentOutOfRangeException(nameof(securityDeposit));

        Id = id;
        ApartmentId = apartmentId;
        TenantId = tenantId;
        StartDate = startDate;
        EndDate = endDate;
        this.RentAmount = RentAmount;
        this.PaymentFrequency = paymentFrequency;
        SecurityDeposit = securityDeposit;
    }

    public bool IsActive => EndDate is null;

    public void Terminate(DateOnly endDate)
    {
        if (!IsActive) throw new InvalidOperationException("Lease already terminated.");
        if (endDate < StartDate) throw new InvalidOperationException("End date cannot be before start date.");
        EndDate = endDate;
        // Optionally raise a domain event here
    }
    public void ChangeRentPaymentFrequency(RentPaymentFrequency newFrequency)
    {
        if (!IsActive) throw new InvalidOperationException("Only active leases can change payment frequency.");
        PaymentFrequency = newFrequency;
    }

    public void ChangeDates(DateOnly newStartDate, DateOnly? newEndDate)
    {
        if (newEndDate is not null && newEndDate < newStartDate)
            throw new ArgumentException("End date cannot be before start date.", nameof(newEndDate));
        StartDate = newStartDate;
        EndDate = newEndDate;
    }

    public void IncreaseRent(Money delta)
    {
        if (!IsActive) throw new InvalidOperationException("Only active leases can change rent.");
        if (delta is null || delta.Amount <= 0) throw new ArgumentOutOfRangeException(nameof(delta));
        if (!RentAmount.SameCurrency(delta)) throw new InvalidOperationException("Currency mismatch.");
        RentAmount = new Money(RentAmount.Amount + delta.Amount, RentAmount.Currency);
    }

    public void ChangeRent(Money newRent)
    {
        if (!IsActive) throw new InvalidOperationException("Only active leases can change rent.");
        if (newRent is null || newRent.Amount <= 0) throw new ArgumentOutOfRangeException(nameof(newRent));
        if (!RentAmount.SameCurrency(newRent)) throw new InvalidOperationException("Currency mismatch.");
        RentAmount = newRent;
    }

    public void ChangeDeposit(Money? newDeposit)
    {
        if (newDeposit is { Amount: < 0 }) throw new ArgumentOutOfRangeException(nameof(newDeposit));
        if (newDeposit is not null && !RentAmount.SameCurrency(newDeposit))
            throw new InvalidOperationException("Deposit currency must match rent currency.");
        SecurityDeposit = newDeposit;
    }

    public void Renew(DateOnly dateOnly)
    {
        if (!IsActive) throw new InvalidOperationException("Only active leases can be renewed.");
        if (dateOnly <= EndDate) throw new InvalidOperationException("New end date must be after current end date.");
        EndDate = dateOnly;
    }

    
}


