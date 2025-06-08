namespace Rental_Management.Business.DTOs.ApartmentBuilding
{
    public class AddApartmentBuildingDTO
    {
        public string BuildingNumber { get; set; } = null!;
        public string StreetAddress { get; set; } = null!;
        public string Neighborhood { get; set; } = null!;

        public string City { get; set; } = null!;
        public int landLordId { get; set; }
    }
}