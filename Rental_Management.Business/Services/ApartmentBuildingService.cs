using Rental_Management.Business.DTOs.ApartmentBuilding;
using Rental_Management.Business.Interfaces;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Services
{
    public class ApartmentBuildingService : IApartmentBuildingService
    {
        readonly IApartmentBuildingRepository _apartmentBuildingRepository;

        public ApartmentBuildingService(IApartmentBuildingRepository apartmentBuildingRepository) 
        {
            _apartmentBuildingRepository = apartmentBuildingRepository;
        }
        public async Task<OperationResultStatus> AddApartmentBuildingAsync(AddApartmentBuildingDTO dto)
        {
            return await _apartmentBuildingRepository.AddAsync(new ApartmentBuilding
            {
                BuildingNumber = dto.BuildingNumber,
                StreetAddress = dto.StreetAddress,
                Neighborhood = dto.Neighborhood,
                City = dto.City,
                LandLordId = dto.landLordId,
            });
        }

        public async Task<OperationResultStatus> DeleteApartmentBuildingAsync(int apartmentBuildingId)
        {
            return await _apartmentBuildingRepository.DeleteAsync(apartmentBuildingId);
        }

        public async Task<ICollection<ApartmentBuildingDTO>> GetAllApartmentBuildingsForLandlord(int landlordId)
        {
            var buildings= await _apartmentBuildingRepository.GetAllApartmentBuildingsForLandlord(landlordId);
            return buildings.Select(x => new ApartmentBuildingDTO
            {
                BuildingNumber = x.BuildingNumber,
                StreetAddress = x.StreetAddress,
                Neighborhood = x.Neighborhood,
                City = x.City,
                LandlordId = x.LandLordId,
            }).ToList();
        }

        public async Task<ApartmentBuildingDTO?> GetApartmentBuildingByIdAsync(int id)
        {
            var apartmentBuilding= await _apartmentBuildingRepository.GetByIdAsync(id);
            if(apartmentBuilding == null)
                return null;

            return new ApartmentBuildingDTO
                {
                    
                    BuildingNumber = apartmentBuilding.BuildingNumber,
                    StreetAddress = apartmentBuilding.StreetAddress,
                    Neighborhood = apartmentBuilding.Neighborhood,
                    City = apartmentBuilding.City,
                    LandlordId = apartmentBuilding.LandLordId,
       
                };
            
        }

        public async Task<OperationResultStatus> UpdateApartmentBuildingAsync(UpdateApartmentBuildingDTO dto)
        {
            ApartmentBuilding? oldApartmentBuilding =await _apartmentBuildingRepository.GetByIdAsync(dto.Id);
            if (oldApartmentBuilding == null)
                return OperationResultStatus.NotFound;
            oldApartmentBuilding.BuildingNumber = dto.BuildingNumber;
            oldApartmentBuilding.StreetAddress = dto.StreetAddress;
            oldApartmentBuilding.Neighborhood = dto.Neighborhood;
            oldApartmentBuilding.City = dto.City;
            return await _apartmentBuildingRepository.UpdateAsync(oldApartmentBuilding);

        }
    }
}
