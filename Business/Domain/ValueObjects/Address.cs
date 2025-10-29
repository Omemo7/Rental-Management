namespace RentalManagement.Business.Domain.ValueObjects;

public sealed record Address
{
    public string Line1 { get; init; }
    public string? Line2 { get; init; }
    public string City { get; init; }
    public string Country { get; init; }
    public string? PostalCode { get; init; }

    public Address(string line1, string? line2, string city, string country, string? postalCode)
    {
        Line1 = string.IsNullOrWhiteSpace(line1) ? throw new ArgumentException("Line1 required.", nameof(line1)) : line1.Trim();
        Line2 = string.IsNullOrWhiteSpace(line2) ? null : line2.Trim();
        City = string.IsNullOrWhiteSpace(city) ? throw new ArgumentException("City required.", nameof(city)) : city.Trim();
        Country = string.IsNullOrWhiteSpace(country) ? throw new ArgumentException("Country required.", nameof(country)) : country.Trim();
        PostalCode = string.IsNullOrWhiteSpace(postalCode) ? null : postalCode.Trim();
    }
}
