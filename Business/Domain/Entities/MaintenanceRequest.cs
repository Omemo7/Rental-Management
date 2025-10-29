// RentalManagement.Business.Domain.Entities/MaintenanceRequest.cs
namespace RentalManagement.Business.Domain.Entities;

public enum MaintenancePriority { Low, Normal, High, Emergency }
public enum MaintenanceStatus { Open, Scheduled, Closed }

public sealed class MaintenanceRequest
{
    public Guid Id { get; private set; }
    public Guid ApartmentId { get; private set; }  // the asset that needs work
    public Guid LandlordId { get; private set; }  // who owns/authorizes
    public Guid? LeaseId { get; private set; }  // optional (who currently occupies)
    public Guid? TenantId { get; private set; }  // optional reporter/billing context

    public string Category { get; private set; }   // "Plumbing", "Electrical", ...
    public string Description { get; private set; }
    public MaintenancePriority Priority { get; private set; }
    public MaintenanceStatus Status { get; private set; }

    public DateTime CreatedAtUtc { get; private set; }
    public DateTime? ScheduledAtUtc { get; private set; }
    public DateTime? CompletedAtUtc { get; private set; }

    // simple costing; you can evolve to line-items later
    public decimal? LaborCost { get; private set; }
    public decimal? PartsCost { get; private set; }
    public string Currency { get; private set; } = "JOD";
    public bool BillToTenant { get; private set; }

    public byte[] RowVersion { get; private set; } = Array.Empty<byte>();

    private MaintenanceRequest() { } // EF

    public MaintenanceRequest(
        Guid id,
        Guid landlordId,
        Guid apartmentId,
        string category,
        string description,
        MaintenancePriority priority,
        Guid? leaseId = null,
        Guid? tenantId = null)
    {
        if (id == Guid.Empty) throw new ArgumentException(nameof(id));
        if (landlordId == Guid.Empty) throw new ArgumentException(nameof(landlordId));
        if (apartmentId == Guid.Empty) throw new ArgumentException(nameof(apartmentId));
        if (string.IsNullOrWhiteSpace(category)) throw new ArgumentException(nameof(category));
        if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException(nameof(description));

        Id = id;
        LandlordId = landlordId;
        ApartmentId = apartmentId;
        LeaseId = leaseId;
        TenantId = tenantId;

        Category = category.Trim();
        Description = description.Trim();
        Priority = priority;
        Status = MaintenanceStatus.Open;

        CreatedAtUtc = DateTime.UtcNow;
    }

    public void Schedule(DateTime whenUtc)
    {
        if (Status == MaintenanceStatus.Closed) throw new InvalidOperationException("Request is closed.");
        ScheduledAtUtc = whenUtc.ToUniversalTime();
        Status = MaintenanceStatus.Scheduled;
    }

    public void Complete(decimal? labor, decimal? parts, string? currency, bool billToTenant)
    {
        if (Status == MaintenanceStatus.Closed) throw new InvalidOperationException("Already closed.");

        LaborCost = labor is > 0 ? labor : null;
        PartsCost = parts is > 0 ? parts : null;

        if (!string.IsNullOrWhiteSpace(currency))
            Currency = currency.Trim().ToUpperInvariant();

        BillToTenant = billToTenant;
        CompletedAtUtc = DateTime.UtcNow;
        Status = MaintenanceStatus.Closed;

        // Optional: raise a domain event like MaintenanceChargeCreated if BillToTenant == true
    }
}
 