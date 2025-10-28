using Rental_Management.Business.DTOs.RentPaymentFrequency;

namespace Rental_Management.Business.Interfaces;

public interface IRentPaymentFrequencyService
{
    Task<List<RentPaymentFrequencyWithIdDTO>> GetRentPaymentFrequenciesAsync();
}
