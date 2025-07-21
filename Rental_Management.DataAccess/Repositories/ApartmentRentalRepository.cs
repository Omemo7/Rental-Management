using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rental_Management.Business.DTOs.ApartmentRental;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;
using Shared;
using Shared.DTOs.ApartmentRental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.DataAccess.Repositories
{
    public class ApartmentRentalRepository : Repository<ApartmentsRental>, IApartmentRentalRepository
    {

       
        public ApartmentRentalRepository(ILogger<Repository<ApartmentsRental>> logger, ApplicationDbContext context) : base(logger, context)
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
            catch(Exception ex)
            {
                _logger.LogError($"Failed to delete ApartmentRental with ID {id}\n" +
                    $"Exception Message: {ex.Message}\n" +
                    $"Inner Exception: {ex.InnerException?.Message ?? "No inner exception"}");
                return OperationResultStatus.Failure;
            }

        }
        public override async Task<ApartmentsRental?> GetByIdAsync(int id)
        {

            return await _dbSet.Include(x => x.Rental).FirstOrDefaultAsync(x => x.Id == id);
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
        public async Task<ICollection<ApartmentRentalDTOForUI>> GetAllApartmentRentalsForLandlordForUI(int landlordId)
        {
            var apartmentRentals = await _dbSet
                .Include(x => x.Rental)
                .ThenInclude(x => x.Tenant)
                .Include(x => x.Rental)
                .ThenInclude(x => x.RentPaymentFrequency)
                .Include(x => x.Apartment)
                .ThenInclude(x => x.ApartmentBuilding)
                .Where(x => x.Apartment.ApartmentBuilding.LandLordId == landlordId)
                .Select(_dbSet => new ApartmentRentalDTOForUI
                {
                    Id = _dbSet.Id,
                    RentValue = _dbSet.Rental.RentValue,
                    RentPaymentFrequency = _dbSet.Rental.RentPaymentFrequency.Frequency,
                    StartDate = _dbSet.Rental.StartDate,
                    EndDate = _dbSet.Rental.EndDate,
                    TenantName = _dbSet.Rental.Tenant.Name,
                    ApartmentName = _dbSet.Apartment.Name,
                    ApartmentId = _dbSet.Apartment.Id,
                    TenantId = _dbSet.Rental.Tenant.Id,
                    RentalId = _dbSet.Rental.Id,
                    IsActive = _dbSet.Rental.IsActive,
                }).ToListAsync();
            return apartmentRentals;
        }
        public async Task<ICollection<ApartmentRentalDTOForUI>> GetAllApartmentRentalsForApartment(int apartmentId)
        {
            var apartmentRentals = await _dbSet
                .Where(x => x.ApartmentId == apartmentId)
                .Include(x => x.Rental)
                .ThenInclude(x => x.Tenant)
                .Include(x => x.Rental)
                .ThenInclude(x => x.RentPaymentFrequency)
                .Select(_dbSet => new ApartmentRentalDTOForUI
                {
                    Id = _dbSet.Id,
                    RentValue = _dbSet.Rental.RentValue,
                    RentPaymentFrequency = _dbSet.Rental.RentPaymentFrequency.Frequency,
                    StartDate = _dbSet.Rental.StartDate,
                    EndDate = _dbSet.Rental.EndDate,
                    TenantName = _dbSet.Rental.Tenant.Name,
                    ApartmentName = _dbSet.Apartment.Name,
                    IsActive = _dbSet.Rental.IsActive,

                }).ToListAsync();
            return apartmentRentals;
        }
        public async Task<ApartmentRentalDTOForUI?> GetByIdAsyncForUI(int id)
        {
            
            var apRental= _dbSet.Where(x => x.Id == id)
                .Include(x => x.Rental)
                .ThenInclude(x => x.Tenant)
                .Include(x=>x.Rental)
                .ThenInclude(x => x.RentPaymentFrequency)
                .Include(x => x.Apartment)
                .Select(_dbSet => new ApartmentRentalDTOForUI
                {
                    Id = _dbSet.Id,
                    RentValue = _dbSet.Rental.RentValue,
                    RentPaymentFrequency = _dbSet.Rental.RentPaymentFrequency.Frequency,
                    StartDate = _dbSet.Rental.StartDate,
                    EndDate = _dbSet.Rental.EndDate,
                    TenantName = _dbSet.Rental.Tenant.Name,
                    ApartmentName = _dbSet.Apartment.Name,
                    IsActive = _dbSet.Rental.IsActive,

                }).FirstOrDefaultAsync();

            return await apRental;

        }

        public async Task<ICollection<ApartmentRentalDTOForTenant>> GetAllApartmentRentalsForTenant(int tenantId)
        {
          var rentals = await _dbSet
         .Where(ar => ar.Rental.TenantId == tenantId)
         .Select(ar => new ApartmentRentalDTOForTenant
         {
             Id = ar.Id,
             ApartmentId = ar.ApartmentId,
             ApartmentName = ar.Apartment.Name,
             RentValue = ar.Rental.RentValue,
             RentPaymentFrequency = ar.Rental.RentPaymentFrequency.Frequency,
             RentalId = ar.Rental.Id,
             StartDate = ar.Rental.StartDate,
             EndDate = ar.Rental.EndDate,
             IsActive = ar.Rental.IsActive

         })
         .ToListAsync();

            return rentals;
        }
    }
}
