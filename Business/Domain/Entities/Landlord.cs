// RentalManagement.Business.Domain.Entities/Landlord.cs
namespace RentalManagement.Business.Domain.Entities;

public sealed class Landlord
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }


    // Optional optimistic concurrency (map in EF Fluent config)
    public byte[] RowVersion { get; private set; } = Array.Empty<byte>();

    private Landlord() { } // EF only

    public Landlord(Guid id, string firstName,string lastName)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id is required.", nameof(id));
        
        this.Id = id;
        this.FirstName = firstName.Trim();
        this.LastName = lastName.Trim();
        
       
    }

    // Behaviors (keep mutations behind intent methods)
    public void ChangeFullName(string firstName,string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("first Name cannot be empty.", nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("last Name cannot be empty.", nameof(lastName));
        this.FirstName = firstName;
        this.LastName = lastName;
    }

  
}
