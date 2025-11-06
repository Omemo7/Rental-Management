using Business.Application.Apartments.Commands;

namespace Presentation.Contracts.Apartments
{
    public class AddApartmentRequest
    {
        public Guid BuildingId { get; set; }
        public Guid LandlordId { get; set; }
        public string UnitNumber { get; set; } = string.Empty;
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public decimal AreaSqm { get; set; }

        public AddApartmentCommand ToCommand()
        {
            return new AddApartmentCommand(BuildingId, LandlordId, UnitNumber, Bedrooms, Bathrooms, AreaSqm);
        }
    }
}
