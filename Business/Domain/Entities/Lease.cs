using RentalManagement.Business.Domain.ValueObjects;

namespace RentalManagement.Business.Domain.Entities;

public sealed class Lease
{
    public Guid Id { get; private set; }
    public Guid ApartmentId { get; private set; }
    public Guid TenantId { get; private set; }

    public DateOnly StartDate { get; private set; }
    public DateOnly? EndDate { get; private set; }

    public Money MonthlyRent { get; private set; }
    public Money? SecurityDeposit { get; private set; }

    // Optimistic concurrency (map in EF Fluent config)
    public byte[] RowVersion { get; private set; } = Array.Empty<byte>();

    private Lease() { } // EF

    public Lease(Guid id, Guid apartmentId, Guid tenantId, DateOnly startDate, Money monthlyRent, Money? securityDeposit = null)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id required.", nameof(id));
        if (apartmentId == Guid.Empty) throw new ArgumentException("ApartmentId required.", nameof(apartmentId));
        if (tenantId == Guid.Empty) throw new ArgumentException("TenantId required.", nameof(tenantId));
        if (monthlyRent is null || monthlyRent.Amount <= 0) throw new ArgumentOutOfRangeException(nameof(monthlyRent));

        if (securityDeposit is { Amount: < 0 }) throw new ArgumentOutOfRangeException(nameof(securityDeposit));

        Id = id;
        ApartmentId = apartmentId;
        TenantId = tenantId;
        StartDate = startDate;
        MonthlyRent = monthlyRent;
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

    public void IncreaseRent(Money delta)
    {
        if (!IsActive) throw new InvalidOperationException("Only active leases can change rent.");
        if (delta is null || delta.Amount <= 0) throw new ArgumentOutOfRangeException(nameof(delta));
        if (!MonthlyRent.SameCurrency(delta)) throw new InvalidOperationException("Currency mismatch.");
        MonthlyRent = new Money(MonthlyRent.Amount + delta.Amount, MonthlyRent.Currency);
    }

    public void ChangeRent(Money newRent)
    {
        if (!IsActive) throw new InvalidOperationException("Only active leases can change rent.");
        if (newRent is null || newRent.Amount <= 0) throw new ArgumentOutOfRangeException(nameof(newRent));
        if (!MonthlyRent.SameCurrency(newRent)) throw new InvalidOperationException("Currency mismatch.");
        MonthlyRent = newRent;
    }

    public void ChangeDeposit(Money? newDeposit)
    {
        if (newDeposit is { Amount: < 0 }) throw new ArgumentOutOfRangeException(nameof(newDeposit));
        if (newDeposit is not null && !MonthlyRent.SameCurrency(newDeposit))
            throw new InvalidOperationException("Deposit currency must match rent currency.");
        SecurityDeposit = newDeposit;
    }
}


