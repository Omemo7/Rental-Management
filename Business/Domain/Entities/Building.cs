// RentalManagement.Business.Domain.Entities/Building.cs
using RentalManagement.Business.Domain.ValueObjects;
using System.Net;

namespace RentalManagement.Business.Domain.Entities;

public sealed class Building
{
    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public Address Address { get; private set; }

    public byte[] RowVersion { get; private set; } = Array.Empty<byte>();

    private Building() { } // EF

    public Building(Guid id, string? name, Address address)
    {
        if (id == Guid.Empty) throw new ArgumentException("Id required.", nameof(id));

        Id = id;
        Name = name?.Trim();
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }

    public void Rename(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName)) throw new ArgumentException("Name required.", nameof(newName));
        Name = newName.Trim();
    }
    public void ChangeAddress(Address newAddress)
    {
        Address = newAddress ?? throw new ArgumentNullException(nameof(newAddress));
    }
}
