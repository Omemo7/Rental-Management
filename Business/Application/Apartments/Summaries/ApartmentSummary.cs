using Business.Application.Buildings.Summaries;
using RentalManagement.Business.Domain.Entities;

namespace Business.Application.Apartments.Summaries
{
    public class ApartmentSummary
    {
        public Guid Id { get; private set; }
        public Guid BuildingId { get; private set; }   // the building it belongs to
        public Guid LandlordId { get; private set; }   // owner of this unit
        public string UnitNumber { get; private set; } // e.g. "3B"
        public int Bedrooms { get; private set; }
        public int Bathrooms { get; private set; }
        public decimal AreaSqm { get; private set; }

        static public ApartmentSummary FromApartment(Apartment apartment)
        {
            return new ApartmentSummary
            {
                Id = apartment.Id,
                BuildingId = apartment.BuildingId,
                LandlordId = apartment.LandlordId,
                UnitNumber = apartment.UnitNumber,
                Bedrooms = apartment.Bedrooms,
                Bathrooms = apartment.Bathrooms,
                AreaSqm = apartment.AreaSqm
            };
        }
    }
}