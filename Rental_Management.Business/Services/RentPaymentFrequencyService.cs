using Rental_Management.DataAccess.Repositories;
using Shared.DTOs.RentPaymentFrequency;
using System.Linq;

namespace Rental_Management.Business.Services;

public static class RentPaymentFrequencyService
{
    public static async Task<List<RentPaymentFrequencyWithIdDTO>> GetRentPaymentFrequencies()
    {
        var frequencies = await RentPaymentFrequencyRepository.GetRentPaymentFrequenciesAsync();
        return frequencies
            .Select(frequency => new RentPaymentFrequencyWithIdDTO
            {
                Id = frequency.Id,
                Frequency = frequency.Frequency
            })
            .ToList();
    }
}
