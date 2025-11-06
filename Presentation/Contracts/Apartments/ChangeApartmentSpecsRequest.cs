using Business.Application.Apartments.Commands;

namespace Presentation.Contracts.Apartments
{
    public class ChangeApartmentSpecsRequest
    {
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public decimal AreaSqm { get; set; }

        public ChangeApartmentSpecsCommand ToCommand(Guid apartmentId)
        {
            return new ChangeApartmentSpecsCommand(apartmentId, Bedrooms, Bathrooms, AreaSqm);
        }
    }
}