using Rental_Management.Business.Entities;

namespace Rental_Management.Business.Interfaces.Repositories;

public interface IRentPaymentFrequencyRepository
{
    Task<List<RentPaymentFrequency>> GetRentPaymentFrequenciesAsync();
}
