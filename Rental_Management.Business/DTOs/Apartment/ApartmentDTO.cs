namespace Rental_Management.Business.DTOs.Apartment
{
    public class ApartmentDTO
    {
        public int Id { get; set; }
        public int FloorNumber { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfBathrooms { get; set; }

        public decimal SquaredMeters { get; set; }

       

        public int ApartmentBuildingId { get; set; }
    }
}