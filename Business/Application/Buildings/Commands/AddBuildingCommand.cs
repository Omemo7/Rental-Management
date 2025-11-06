namespace Business.Application.Buildings.Commands
{
    public class AddBuildingCommand
    {
        public AddBuildingCommand(string? name, string? street, string? neighborhood, string city, string country, string? postalCode)
        {
            Name = name;
            Street = street;
            Neighborhood = neighborhood;
            City = city;
            Country = country;
            PostalCode = postalCode;
        }

        public string? Name { get; set; }
        public string? Street { get; set; }
        public string? Neighborhood { get; set; }
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string? PostalCode { get; set; }

        
    }

}