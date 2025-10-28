using Rental_Management.Business.DTOs.Apartment;
using Rental_Management.Business.DTOs.ApartmentBuilding;
using Rental_Management.Business.DTOs.Landlord;
using Rental_Management.Business.DTOs.Tenant;

namespace Rental_Management.Business.Interfaces
{
    public interface ILandlordService : IService<LandlordDTO, AddLandlordDTO, UpdateLandlordDTO>
    {
        Task<ICollection<ApartmentBuildingDTO>> GetAllApartmentBuildingsForLandlord(int landlordId);
        Task<ICollection<ApartmentBuildingIdAndNODTO>> GetAllApartmentBuildingsIdAndNOForLandlord(int landlordId);
        Task<ICollection<ApartmentIdAndNameDTO>> GetAllApartmentsIdAndNameForLandlord(int landlordId);
        Task<ICollection<TenantIdAndNameDTO>> GetAllTenantsIdAndNameForLandlord(int landlordId);
        Task<ICollection<ApartmentDTO>> GetAllApartmentsForLandlord(int landlordId);
        Task<ICollection<TenantDTO>> GetAllTenantsForLandlord(int landlordId);
    }
}
