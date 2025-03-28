using Microsoft.Extensions.Logging;
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
        readonly ILogger<ApartmentBuildingService> _logger;

        public ApartmentBuildingService(IApartmentBuildingRepository apartmentBuildingRepository,ILogger<ApartmentBuildingService>logger) 
        {
            _apartmentBuildingRepository = apartmentBuildingRepository;
            _logger = logger;
        }
       
        public async Task<int> AddAsync(AddApartmentBuildingDTO dto)
        {
            
            if (dto == null)
            {
                _logger.LogWarning("Invalid AddApartmentBuildingDTO");
                return -1;
            }
                
            return await _apartmentBuildingRepository.AddAsync(new ApartmentBuilding
            {
                BuildingNumber = dto.BuildingNumber,
                StreetAddress = dto.StreetAddress,
                Neighborhood = dto.Neighborhood,
                City = dto.City,
                LandLordId = dto.landLordId,
            });
        }

        

        public async Task<OperationResultStatus> DeleteAsync(int Id)
        {
            return await _apartmentBuildingRepository.DeleteAsync(Id);
        }

        public async Task<ICollection<ApartmentBuildingDTO>> GetAllApartmentBuildingsForLandlord(int landlordId)
        {
            var buildings= await _apartmentBuildingRepository.GetAllApartmentBuildingsForLandlord(landlordId);
            return buildings.Select(x => new ApartmentBuildingDTO
            {
                Id = x.Id,
                BuildingNumber = x.BuildingNumber,
                StreetAddress = x.StreetAddress,
                Neighborhood = x.Neighborhood,
                City = x.City,
                LandlordId = x.LandLordId,
            }).ToList();
        }

        public async Task<ApartmentBuildingDTO?> GetByIdAsync(int id)
        {
            var apartmentBuilding = await _apartmentBuildingRepository.GetByIdAsync(id);
            if (apartmentBuilding == null)
            {
                _logger.LogWarning("Invalid Apartment Building");
                return null;
            }
            return new ApartmentBuildingDTO
            {
                Id= apartmentBuilding.Id,
                BuildingNumber = apartmentBuilding.BuildingNumber,
                StreetAddress = apartmentBuilding.StreetAddress,
                Neighborhood = apartmentBuilding.Neighborhood,
                City = apartmentBuilding.City,
                LandlordId = apartmentBuilding.LandLordId,

            };
        }

        public async Task<OperationResultStatus> UpdateAsync(UpdateApartmentBuildingDTO dto)
        {
            
            if (dto == null)
            {
                _logger.LogWarning("Invalid UpdateApartmentBuildingDTO");
                return OperationResultStatus.Failure;
            }
            ApartmentBuilding? oldApartmentBuilding = await _apartmentBuildingRepository.GetByIdAsync(dto.Id);
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
