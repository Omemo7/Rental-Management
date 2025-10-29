namespace RentalManagement.Business.Domain.Entities;

public sealed class Tenant
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; }
    public string? Email { get; private set; }
    public string? PhoneNumber { get; private set; }

    // OPT: RowVersion for concurrency if tenants can be edited by many
    public byte[] RowVersion { get; private set; } = Array.Empty<byte>();

    private Tenant() { } // EF only

    public Tenant(Guid id, string fullName, string? email = null, string? phoneNumber = null)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id is required.", nameof(id));
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Full name is required.", nameof(fullName));

        Id = id;
        FullName = NormalizeName(fullName);

        if (!string.IsNullOrWhiteSpace(email))
            Email = NormalizeEmail(email);

        if (!string.IsNullOrWhiteSpace(phoneNumber))
            PhoneNumber = phoneNumber.Trim();
    }

    public void ChangeFullName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("Name cannot be empty.", nameof(newName));

        FullName = NormalizeName(newName);
    }

    public void ChangeEmail(string? newEmail)
    {
        Email = string.IsNullOrWhiteSpace(newEmail)
            ? null
            : NormalizeEmail(newEmail);
    }

    public void ChangePhoneNumber(string? newPhone)
    {
        PhoneNumber = string.IsNullOrWhiteSpace(newPhone)
            ? null
            : newPhone.Trim();
    }

    private static string NormalizeName(string name)
        => name.Trim();

    private static string NormalizeEmail(string email)
    {
        var normalized = email.Trim().ToLowerInvariant();
        // optional: regex validation can go here, but keep it lightweight in domain
        if (!normalized.Contains('@')) throw new ArgumentException("Invalid email format.", nameof(email));
        return normalized;
    }
}
