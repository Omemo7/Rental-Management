using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;

namespace Rental_Management.DataAccess.Repositories;

public class ApartmentRepository : Repository<Apartment>, IApartmentRepository
{
    public ApartmentRepository(ILogger<Repository<Apartment>> logger, ApplicationDbContext context)
        : base(logger, context)
    {
    }

    public async Task<int> AddApartmentMaintenance(Maintenance entity)
    {
        _context.Maintenances.Add(entity);
        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public decimal GetApartmentTotalMaintenance(int apartmentId)
    {
        return _context.Maintenances
            .Where(m => m.ApartmentId == apartmentId)
            .Sum(m => m.Cost);
    }

    public decimal GetApartmentTotalPayments(int apartmentId)
    {
        return _context.Payments
            .Include(p => p.Rental)
                .ThenInclude(r => r.ApartmentRental)
            .Where(p => p.Rental.ApartmentRental.ApartmentId == apartmentId)
            .Sum(p => p.PaidAmount);
    }
}
