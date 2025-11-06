using Business.Application.Buildings.Commands;

namespace Presentation.Contracts.Buildings
{
    public class ChangeAddressRequest
    {
        public string? Street { get; set; }
        public string? Neighborhood { get; set; }
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string? PostalCode { get; set; }

        public ChangeAddressCommand ToCommand(Guid buildingId)
        {
            return new ChangeAddressCommand(buildingId, Street, Neighborhood, City, Country, PostalCode);
        }
    }
}
