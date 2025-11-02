namespace RentalManagement.Business.Domain.ValueObjects;

public sealed record Address
{
    public string? Street { get; init; }
    public string? Neighborhood { get; init; }
    public string City { get; init; }
    public string Country { get; init; }
    public string? PostalCode { get; init; }

    public Address(string? street, string? neighborhood, string city, string country, string? postalCode)
    {

        Street = string.IsNullOrWhiteSpace(street) ? null : street.Trim();
        Neighborhood = string.IsNullOrWhiteSpace(neighborhood) ? null : neighborhood.Trim();
        City = string.IsNullOrWhiteSpace(city) ? throw new ArgumentException("City required.", nameof(city)) : city.Trim();
        Country = string.IsNullOrWhiteSpace(country) ? throw new ArgumentException("Country required.", nameof(country)) : country.Trim();
        PostalCode = string.IsNullOrWhiteSpace(postalCode) ? null : postalCode.Trim();
    }
}
