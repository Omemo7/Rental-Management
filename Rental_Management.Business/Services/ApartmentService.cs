using Microsoft.Extensions.Logging;
using Rental_Management.Business.DTOs.Apartment;
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
    public class ApartmentService : IApartmentService
    {
        IApartmentRepository _apartmentRepository;
        ILogger<ApartmentService> _logger;
        public ApartmentService(IApartmentRepository repository,ILogger<ApartmentService> logger) 
        {
            _apartmentRepository = repository;
            _logger = logger;
        }
        public async Task<OperationResultStatus> AddAsync(object AddDTO)
        {
            AddApartmentDTO? dto = AddDTO as AddApartmentDTO;
            if (dto == null)
            {
                _logger.LogWarning("Invalid AddApartmentDTO");
                return OperationResultStatus.Failure;
            }
            return await _apartmentRepository.AddAsync(new Apartment
            {
                FloorNumber = dto.FloorNumber,
                NumberOfRooms = dto.NumberOfRooms,
                NumberOfBathrooms = dto.NumberOfBathrooms,
                SquaredMeters = dto.SquaredMeters,
                ApartmentBuildingId = dto.ApartmentBuildingId,
                
            });
            
        }

        public async Task<OperationResultStatus> DeleteAsync(int Id)
        {
            return await _apartmentRepository.DeleteAsync(Id);
        }

        public async Task<ICollection<ApartmentDTO>> GetAllApartmentsForLandlord(int landlordId)
        {
            var apartments = await _apartmentRepository.GetAllApartmentsForLandlord(landlordId);
            return apartments.Select(x => new ApartmentDTO
            {
                Id = x.Id,
                NumberOfBathrooms = x.NumberOfBathrooms,
                NumberOfRooms = x.NumberOfRooms,
                FloorNumber = x.FloorNumber,
                SquaredMeters = x.SquaredMeters,
                ApartmentBuildingId = x.ApartmentBuildingId,
                
            }).ToList();
           
        }

        public async Task<ICollection<ApartmentDTO>> GetAllApartmentsInBuilding(int apartmentBuildingId)
        {
            var apartments = await _apartmentRepository.GetAllApartmentsInBuilding(apartmentBuildingId);
            return apartments.Select(x => new ApartmentDTO
            {
                Id = x.Id,
                FloorNumber = x.FloorNumber,
                SquaredMeters = x.SquaredMeters,
                NumberOfBathrooms = x.NumberOfBathrooms,
                NumberOfRooms = x.NumberOfRooms,
                ApartmentBuildingId = x.ApartmentBuildingId,
               
            }).ToList();
        }

        public async Task<object?> GetByIdAsync(int id)
        {
            return await _apartmentRepository.GetByIdAsync(id);
        }

        public async Task<OperationResultStatus> UpdateAsync(object UpdateDTO)
        {
            var dto = UpdateDTO as UpdateApartmentDTO;
            if (dto == null)
            {
                _logger.LogWarning("Invalid UpdateApartmentDTO");
                return OperationResultStatus.Failure;
            }
            var oldApartment= await _apartmentRepository.GetByIdAsync(dto.Id);
            if (oldApartment == null)
            {
                _logger.LogWarning("Apartment not found");
                return OperationResultStatus.NotFound;
            }
            oldApartment.FloorNumber = dto.FloorNumber;
            oldApartment.SquaredMeters = dto.SquaredMeters;
            oldApartment.NumberOfBathrooms = dto.NumberOfBathrooms;
            oldApartment.NumberOfRooms = dto.NumberOfRooms;
            return await _apartmentRepository.UpdateAsync(oldApartment);
            
        }
    }
}
