using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rental_Management.Business.DTOs.ApartmentRental;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;
using Shared.DTOs.Apartment;
using Shared.DTOs.ApartmentBuilding;
using Shared.DTOs.Tenant;
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
        public async Task<ICollection<ApartmentBuildingIdAndNODTO>> GetAllApartmentBuildingsIdAndNOForLandlord(int landlordId)
        {
            return await _context.ApartmentBuildings.Where(x => x.LandLordId==landlordId).Select(x=>new ApartmentBuildingIdAndNODTO {Id=x.Id,NO=x.BuildingNumber }).ToListAsync();
        }

        public async Task<ICollection<Apartment>> GetAllApartmentsForLandlord(int landlordId)
        {
            return await _context.Apartments.Where(x => x.ApartmentBuilding.LandLordId == landlordId).ToListAsync();
        }

        public async Task<ICollection<Tenant>> GetAllTenantsForLandlord(int landlordId)
        {
            return await _context.Tenants.Where(x => x.LandlordId == landlordId).ToListAsync();
        }
        public async Task<ICollection<ApartmentsRental>> GetAllVacantApartmentRentalsForLandlord(int landlordId)
        {
            return await _context.ApartmentsRentals
                .Include(x=>x.Rental)
                .Include(x => x.Apartment)
                .ThenInclude(x => x.ApartmentBuilding)
                .Where(x => x.Apartment.ApartmentBuilding.LandLordId == landlordId && !x.Apartment.Occupied)
                .ToListAsync();
        }

        public async Task<ICollection<ApartmentIdAndNameDTO>> GetAllApartmentsIdAndNameForLandlord(int landlordId)
        {
            return await _context.Apartments
                .Where(x => x.ApartmentBuilding.LandLordId == landlordId)
                .Select(x => new ApartmentIdAndNameDTO { Id = x.Id, Name = x.Name })
                .ToListAsync();
        }

        public async Task<ICollection<TenantIdAndNameDTO>> GetAllTenantsIdAndNameForLandlord(int landlordId)
        {
            return await _context.Tenants
                .Where(x => x.LandlordId == landlordId)
                .Select(x => new TenantIdAndNameDTO { Id = x.Id, Name = x.Name })
                .ToListAsync();
        }

        public async Task<ICollection<ApartmentRentalDTOForUI>> GetAllApartmentRentalsForLandlordForUI(int landlordId)
        {
            var apRentals = await _context.ApartmentsRentals
                .Where(x => x.Apartment.ApartmentBuilding.LandLordId == landlordId)
                .Include(x => x.Rental)
                    .ThenInclude(r => r.Tenant)
                .Include(x => x.Rental)
                    .ThenInclude(r => r.RentPaymentFrequency)
                .Include(x => x.Apartment)
                .Select(r => new ApartmentRentalDTOForUI
                {
                    Id = r.Id,
                    RentValue = r.Rental.RentValue,
                    RentPaymentFrequency = r.Rental.RentPaymentFrequency.Frequency,
                    StartDate = r.Rental.StartDate,
                    EndDate = r.Rental.EndDate,
                    TenantName = r.Rental.Tenant.Name,
                    ApartmentName = r.Apartment.Name
                })
                .ToListAsync();

            return apRentals;
        }

        
    }
}
