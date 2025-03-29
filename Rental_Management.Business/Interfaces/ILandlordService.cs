using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental_Management.Business.DTOs.Apartment;
using Rental_Management.Business.DTOs.ApartmentBuilding;
using Rental_Management.Business.DTOs.Landlord;
using Rental_Management.Business.DTOs.Tenant;
using Shared;

namespace Rental_Management.Business.Interfaces
{
    public interface ILandlordService: IService<LandlordDTO,AddLandlordDTO,UpdateLandlordDTO>
    {
        public Task<ICollection<ApartmentBuildingDTO>> GetAllApartmentBuildingsForLandlord(int landlordId);

        public Task<ICollection<ApartmentDTO>> GetAllApartmentsForLandlord(int landlordId);

        public Task<ICollection<TenantDTO>> GetAllTenantsForLandlord(int landlordId);

    }
}
