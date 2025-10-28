using Rental_Management.Business.DTOs.RentPaymentFrequency;
using Rental_Management.Business.Interfaces;
using Rental_Management.Business.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Rental_Management.Business.Services;

public class RentPaymentFrequencyService : IRentPaymentFrequencyService
{
    private readonly IRentPaymentFrequencyRepository _rentPaymentFrequencyRepository;

    public RentPaymentFrequencyService(IRentPaymentFrequencyRepository rentPaymentFrequencyRepository)
    {
        _rentPaymentFrequencyRepository = rentPaymentFrequencyRepository;
    }

    public async Task<List<RentPaymentFrequencyWithIdDTO>> GetRentPaymentFrequenciesAsync()
    {
        var frequencies = await _rentPaymentFrequencyRepository.GetRentPaymentFrequenciesAsync();
        return frequencies
            .Select(frequency => new RentPaymentFrequencyWithIdDTO
            {
                Id = frequency.Id,
                Frequency = frequency.Frequency
            })
            .ToList();
    }
}
