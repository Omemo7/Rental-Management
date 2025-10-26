using Microsoft.EntityFrameworkCore;
using Rental_Management.DataAccess.Entities;

namespace Rental_Management.DataAccess.Repositories;

public static class RentPaymentFrequencyRepository
{
    private static readonly ApplicationDbContext _context = new ApplicationDbContext();

    public static async Task<List<RentPaymentFrequency>> GetRentPaymentFrequenciesAsync()
    {
        return await _context.RentPaymentFrequency.ToListAsync();
    }
}
