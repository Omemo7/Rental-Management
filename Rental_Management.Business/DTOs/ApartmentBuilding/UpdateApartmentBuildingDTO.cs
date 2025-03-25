namespace Rental_Management.Business.DTOs.ApartmentBuilding
{
    public class UpdateApartmentBuildingDTO
    {
        public int Id { get; set; }
        public string BuildingNumber { get; set; } = null!;
        public string StreetAddress { get; set; } = null!;
        public string Neighborhood { get; set; } = null!;

        public string City { get; set; } = null!;
        
    }
}