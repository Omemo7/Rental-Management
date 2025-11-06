namespace Business.Application.Apartments.Commands
{
    public class AddApartmentCommand
    {
        public AddApartmentCommand(Guid buildingId, Guid landlordId, string unitNumber, int bedrooms, int bathrooms, decimal areaSqm)
        {
            BuildingId = buildingId;
            LandlordId = landlordId;
            UnitNumber = unitNumber;
            Bedrooms = bedrooms;
            Bathrooms = bathrooms;
            AreaSqm = areaSqm;
        }

        public Guid BuildingId { get; set; }   // the building it belongs to
        public Guid LandlordId { get; set; }   // owner of this unit
        public string UnitNumber { get; set; } // e.g. "3B"
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public decimal AreaSqm { get; set; }

    }
}