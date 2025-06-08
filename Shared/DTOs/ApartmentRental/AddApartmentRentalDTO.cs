using Rental_Management.Business.DTOs.Rental;

namespace Rental_Management.Business.DTOs.ApartmentRental
{
    public class AddApartmentRentalDTO
    {
        public int ApartmentId { get; set; }
        public RentalDTO Rental { get; set; } = null!;

        
    }
}