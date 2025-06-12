using Rental_Management.Business.DTOs.ApartmentRental;
using Rental_Management.DataAccess.Entities;
using Shared.DTOs.Apartment;
using Shared.DTOs.ApartmentBuilding;
using Shared.DTOs.Tenant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.DataAccess.Interfaces
{
    public interface ILandlordRepository : IRepository<Landlord>
    {
        public Task<ICollection<ApartmentBuilding>> GetAllApartmentBuildingsForLandlord(int landlordId);
        public Task<ICollection<Apartment>> GetAllApartmentsForLandlord(int landlordId);

        public Task<ICollection<Tenant>> GetAllTenantsForLandlord(int landlordId);

        public Task<ICollection<ApartmentIdAndNameDTO>> GetAllApartmentsIdAndNameForLandlord(int landlordId);
        public Task<ICollection<TenantIdAndNameDTO>> GetAllTenantsIdAndNameForLandlord(int landlordId);

        public Task<ICollection<ApartmentsRental>> GetAllVacantApartmentRentalsForLandlord(int landlordId);

        public Task<ICollection<ApartmentRentalDTOForUI>> GetAllApartmentRentalsForLandlordForUI(int landlordId);

        public Task<ICollection<ApartmentBuildingIdAndNODTO>> GetAllApartmentBuildingsIdAndNOForLandlord(int landlordId);
        
    }
}
