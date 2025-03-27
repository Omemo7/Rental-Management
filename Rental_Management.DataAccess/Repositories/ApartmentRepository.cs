using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.DataAccess.Repositories
{
    public class ApartmentRepository:Repository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(ILogger<Repository<Apartment>> logger, ApplicationDbContext context) : base(logger, context)
        {
        }

        public async Task<ICollection<Apartment>> GetAllApartmentsForLandlord(int landlordId)
        {
             return await _dbSet.Include(a=>a.ApartmentBuilding).Where(a=>a.ApartmentBuilding.LandLordId==landlordId).ToListAsync();

        }
        public async Task<ICollection<Apartment>> GetAllApartmentsInBuilding(int apartmentBuildingId)
        {
            return await _dbSet.Where(a => a.ApartmentBuildingId == apartmentBuildingId).ToListAsync();
        }
    }
    
}
