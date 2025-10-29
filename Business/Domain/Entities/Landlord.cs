// RentalManagement.Business.Domain.Entities/Landlord.cs
namespace RentalManagement.Business.Domain.Entities;

public sealed class Landlord
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public string? Email { get; private set; }
    public string? PhoneNumber { get; private set; }
    public bool IsActive { get; private set; } = true;

    // Optional optimistic concurrency (map in EF Fluent config)
    public byte[] RowVersion { get; private set; } = Array.Empty<byte>();

    private Landlord() { } // EF only

    public Landlord(Guid id, string fullName, string? email = null, string? phoneNumber = null)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id is required.", nameof(id));
        if (string.IsNullOrWhiteSpace(fullName)) throw new ArgumentException("Full name is required.", nameof(fullName));

        Id = id;
        FullName = NormalizeName(fullName);
        Email = string.IsNullOrWhiteSpace(email) ? null : NormalizeEmail(email);
        PhoneNumber = string.IsNullOrWhiteSpace(phoneNumber) ? null : phoneNumber.Trim();
        IsActive = true;
    }

    // Behaviors (keep mutations behind intent methods)
    public void ChangeFullName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName)) throw new ArgumentException("Name cannot be empty.", nameof(newName));
        FullName = NormalizeName(newName);
    }

    public void ChangeEmail(string? newEmail)
        => Email = string.IsNullOrWhiteSpace(newEmail) ? null : NormalizeEmail(newEmail);

    public void ChangePhoneNumber(string? newPhone)
        => PhoneNumber = string.IsNullOrWhiteSpace(newPhone) ? null : newPhone.Trim();

    public void Deactivate() => IsActive = false;
    public void Reactivate() => IsActive = true;

    // Helpers
    private static string NormalizeName(string name) => name.Trim();

    private static string NormalizeEmail(string email)
    {
        var normalized = email.Trim().ToLowerInvariant();
        if (!normalized.Contains('@')) throw new ArgumentException("Invalid email format.", nameof(email));
        return normalized;
    }
}
