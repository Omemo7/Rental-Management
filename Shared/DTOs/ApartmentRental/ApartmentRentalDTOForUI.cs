using Rental_Management.Business.DTOs.Rental;

namespace Rental_Management.Business.DTOs.ApartmentRental
{
    public class ApartmentRentalDTOForUI
    {
        public int Id { get; set; } 
        public string ApartmentName { get; set; } =null!;
        public string TenantName { get; set; } = null!;
        public decimal RentValue { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }

        public string RentPaymentFrequency { get; set; } = null!;


    }
}