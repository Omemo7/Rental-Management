using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.DataAccess.Repositories
{
    public class ApartmentBuildingRepository : Repository<ApartmentBuilding>,IApartmentBuildingRepository
    {
        public ApartmentBuildingRepository(ILogger<Repository<ApartmentBuilding>> logger, ApplicationDbContext context) : base(logger, context)
        {
        }


        public async Task<ICollection<Apartment>> GetAllApartmentsInBuilding(int apartmentBuildingId)
        {
            return await _context.Apartments.Where(a => a.ApartmentBuildingId == apartmentBuildingId).ToListAsync();
        }
    }
}
