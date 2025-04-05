using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;
using Shared;
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
       
            return await _dbSet.Include(x=>x.Rental).FirstOrDefaultAsync(x=>x.Id==id);

        }

    }
}
