using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.DataAccess.Repositories
{
    public class LandlordRepository:Repository<Landlord>, ILandlordRepository
    {
        public LandlordRepository(ILogger<LandlordRepository> logger,ApplicationDbContext context) : base(logger,context)
        {

        }

        public async Task<ICollection<ApartmentBuilding>> GetAllApartmentBuildingsForLandlord(int landlordId)
        {
            return await _context.ApartmentBuildings.Where(x => x.LandLordId == landlordId).ToListAsync();
            
        }

        public async Task<ICollection<Apartment>> GetAllApartmentsForLandlord(int landlordId)
        {
            return await _context.Apartments.Where(x => x.ApartmentBuilding.LandLordId == landlordId).ToListAsync();
        }

        public async Task<ICollection<Tenant>> GetAllTenantsForLandlord(int landlordId)
        {
            return await _context.Tenants.Where(x => x.LandlordId == landlordId).ToListAsync();
        }
    }
}
