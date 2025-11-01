namespace Business.Application.Buildings.Commands
{
    public class ChangeAddressCommand
    {
        public Guid BuildingId { get; set; }
        public string? Street { get; set; }
        public string? Neighborhood { get; set; }
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string? PostalCode { get; set; }
    }
}