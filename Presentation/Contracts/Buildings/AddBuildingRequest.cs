namespace Presentation.Contracts.Buildings
{
    public class AddBuildingRequest
    {
        public string? Name { get; set; }
        public string? Street { get; set; }
        public string? Neighborhood { get; set; }
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string? PostalCode { get; set; }
    }
}
