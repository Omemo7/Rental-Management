using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rental_Management.Business.Entities;
using Rental_Management.Business.Interfaces.Repositories;
using Rental_Management.Business.Common;

namespace Rental_Management.DataAccess.Repositories;

public class ApartmentRentalRepository : Repository<ApartmentsRental>, IApartmentRentalRepository
{
    public ApartmentRentalRepository(ILogger<Repository<ApartmentsRental>> logger, ApplicationDbContext context)
        : base(logger, context)
    {
    }

    public override async Task<OperationResultStatus> DeleteAsync(int id)
    {
        try
        {
            var apartmentRental = await _context.ApartmentsRentals
                .Include(x => x.Rental)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (apartmentRental == null)
            {
                _logger.LogWarning("ApartmentRental with ID {0} not found", id);
                return OperationResultStatus.NotFound;
            }

            _context.ApartmentsRentals.Remove(apartmentRental);
            if (apartmentRental.Rental != null)
            {
                _context.Rentals.Remove(apartmentRental.Rental);
            }

            await _context.SaveChangesAsync();

            return OperationResultStatus.Success;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to delete ApartmentRental with ID {id}\n" +
                              $"Exception Message: {ex.Message}\n" +
                              $"Inner Exception: {ex.InnerException?.Message ?? "No inner exception"}");
            return OperationResultStatus.Failure;
        }
    }

    public override async Task<ApartmentsRental?> GetByIdAsync(int id)
    {
        return await _dbSet
            .Include(x => x.Rental)
                .ThenInclude(r => r.RentPaymentFrequency)
            .Include(x => x.Rental)
                .ThenInclude(r => r.Tenant)
            .Include(x => x.Apartment)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public override async Task<int> AddAsync(ApartmentsRental entity)
    {
        try
        {
            var apartment = await _context.Apartments.FirstOrDefaultAsync(a => a.Id == entity.ApartmentId);
            if (apartment == null)
            {
                _logger.LogWarning("Apartment with ID {0} not found.", entity.ApartmentId);
                return -1;
            }

            apartment.Occupied = true;
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            var id = entity.Id;
            if (id > 0)
            {
                _logger.LogInformation("Added entity of type {0} successfully with ID {1}", "apartment rental", id);
                return id;
            }

            _logger.LogWarning("Entity does not have an 'Id' property.");
            return -1;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to add entity of type \"apartment rental\"\n" +
                              $"Exception Message: {ex.Message}\n" +
                              $"Inner Exception: {ex.InnerException?.Message ?? "No inner exception"}");

            return -1;
        }
    }

    public async Task<ICollection<ApartmentsRental>> GetAllForLandlordAsync(int landlordId)
    {
        return await _dbSet
            .Include(x => x.Rental)
                .ThenInclude(r => r.Tenant)
            .Include(x => x.Rental)
                .ThenInclude(r => r.RentPaymentFrequency)
            .Include(x => x.Apartment)
                .ThenInclude(a => a.ApartmentBuilding)
            .Where(x => x.Apartment.ApartmentBuilding.LandLordId == landlordId)
            .ToListAsync();
    }

    public async Task<ICollection<ApartmentsRental>> GetAllForApartmentAsync(int apartmentId)
    {
        return await _dbSet
            .Where(x => x.ApartmentId == apartmentId)
            .Include(x => x.Rental)
                .ThenInclude(r => r.Tenant)
            .Include(x => x.Rental)
                .ThenInclude(r => r.RentPaymentFrequency)
            .Include(x => x.Apartment)
            .ToListAsync();
    }

    public async Task<ICollection<ApartmentsRental>> GetAllForTenantAsync(int tenantId)
    {
        return await _dbSet
            .Where(ar => ar.Rental.TenantId == tenantId)
            .Include(ar => ar.Rental)
                .ThenInclude(r => r.RentPaymentFrequency)
            .Include(ar => ar.Apartment)
            .ToListAsync();
    }

    public async Task<ApartmentsRental?> GetByIdWithDetailsAsync(int id)
    {
        return await _dbSet
            .Where(x => x.Id == id)
            .Include(x => x.Rental)
                .ThenInclude(r => r.Tenant)
            .Include(x => x.Rental)
                .ThenInclude(r => r.RentPaymentFrequency)
            .Include(x => x.Apartment)
                .ThenInclude(a => a.ApartmentBuilding)
            .FirstOrDefaultAsync();
    }
}
