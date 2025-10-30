namespace RentalManagement.Business.Domain.Entities;

public sealed class Tenant
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string? Email { get; private set; }
    public string? PhoneNumber { get; private set; }

    // OPT: RowVersion for concurrency if tenants can be edited by many
    public byte[] RowVersion { get; private set; } = Array.Empty<byte>();

    private Tenant() { } // EF only

    public Tenant(Guid id, string firstName,string lastName, string? email = null, string? phoneNumber = null)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id is required.", nameof(id));
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name is required.", nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name is required.", nameof(lastName));

        Id = id;
       
        FirstName= firstName.Trim();
        LastName= lastName.Trim();

        if (!string.IsNullOrWhiteSpace(email))
            Email = NormalizeEmail(email);

        if (!string.IsNullOrWhiteSpace(phoneNumber))
            PhoneNumber = phoneNumber.Trim();
    }

    public void ChangeFullName(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("first Name cannot be empty.", nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("last Name cannot be empty.", nameof(lastName));
        this.FirstName = firstName;
        this.LastName = lastName;
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

    

    private static string NormalizeEmail(string email)
    {
        var normalized = email.Trim().ToLowerInvariant();
        // optional: regex validation can go here, but keep it lightweight in domain
        if (!normalized.Contains('@')) throw new ArgumentException("Invalid email format.", nameof(email));
        return normalized;
    }
}
