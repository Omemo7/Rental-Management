using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;
using Shared.DTOs.Apartment;
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

        public async Task<int> AddApartmentMaintenance(Maintenance entity)
        {
            _context.Maintenances.Add(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
            
        }

        public decimal GetApartmentTotalProfit(int apartmentId)
        {
           var cost= _context.Maintenances.Where(m=>m.ApartmentId==apartmentId)
                .Sum(m => m.Cost);
           var profit= _context.Payments.Include(p => p.Rental).ThenInclude(p => p.ApartmentRental).
                Where(p => p.Rental.ApartmentRental.ApartmentId == apartmentId)
                .Sum(p => p.PaidAmount);

            return profit- cost;

        }
    }
    
}
