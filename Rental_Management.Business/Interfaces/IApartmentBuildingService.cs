using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental_Management.Business.DTOs.ApartmentBuilding;
using Shared;
namespace Rental_Management.Business.Interfaces
{
    public interface IApartmentBuildingService
    {
        public Task<OperationResultStatus> AddApartmentBuildingAsync(AddApartmentBuildingDTO dto);
        public Task<OperationResultStatus> DeleteApartmentBuildingAsync(int apartmentBuildingId);
        public Task<OperationResultStatus> UpdateApartmentBuildingAsync(UpdateApartmentBuildingDTO dto);
        public Task<ApartmentBuildingDTO?> GetApartmentBuildingByIdAsync(int id);
        public Task<ICollection<ApartmentBuildingDTO>> GetAllApartmentBuildingsForLandlord(int landlordId);
    }
}
