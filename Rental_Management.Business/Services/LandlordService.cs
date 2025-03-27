using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental_Management.Business.Interfaces;
using Rental_Management.DataAccess.Interfaces;
using Rental_Management.DataAccess.Entities;
using Microsoft.Identity.Client;
using Microsoft.Extensions.Logging;
using Shared;
using Rental_Management.Business.DTOs.Landlord;
namespace Rental_Management.Business.Services
{
    public class LandlordService : ILandlordService
    {
        readonly IRepository<Landlord> _landlordRepository;
        readonly ILogger<LandlordService> _logger;

        public LandlordService(IRepository<Landlord> landlordRepository,ILogger<LandlordService>logger)
        {
            _landlordRepository = landlordRepository;
            _logger = logger;

        }

        public async Task<OperationResultStatus> AddAsync(object AddDTO)
        {
            var dto = AddDTO as AddLandlordDTO;
            if (dto == null)
            {
                _logger.LogWarning("Invalid AddLandlordDTO");
                return OperationResultStatus.Failure;
            }
            bool landlordWithUsernameExists = await _landlordRepository.ExistsAsync(l => l.Username == dto.Username);
            bool landlordWithEmailExists = await _landlordRepository.ExistsAsync(l => l.Email == dto.Email);
            bool landlordWithPhoneExists = await _landlordRepository.ExistsAsync(l => l.PhoneNumber == dto.PhoneNumber);
            if (landlordWithUsernameExists)
            {
                _logger.LogWarning("Landlord with username already exists");
                return OperationResultStatus.Conflict;
            }
            if (landlordWithEmailExists)
            {
                _logger.LogWarning("Landlord with email already exists");
                return OperationResultStatus.Conflict;
            }
            if (landlordWithPhoneExists)
            {
                _logger.LogWarning("Landlord with phone number already exists");
                return OperationResultStatus.Conflict;
            }
            Landlord landlord = new Landlord
            {

                Username = dto.Username,
                Password = dto.Password,
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,

            };

            return await _landlordRepository.AddAsync(landlord);

        }

        

        public async Task<OperationResultStatus> DeleteAsync(int Id)
        {
            return await _landlordRepository.DeleteAsync(Id);
        }

       

        public async Task<object?> GetByIdAsync(int id)
        {
            var landlord = await _landlordRepository.GetByIdAsync(id);

            if (landlord == null)
                return null;
            return new LandlordDTO
            {
                Id = landlord.Id,
                Username = landlord.Username,
                Name = landlord.Name,
                Email = landlord.Email,
                PhoneNumber = landlord.PhoneNumber,
            };
        }

       
        public async Task<OperationResultStatus> UpdateAsync(object UpdateDTO)
        {
            var dto = UpdateDTO as UpdateLandlordDTO;
            if (dto == null)
            {
                _logger.LogWarning("Invalid UpdateLandlordDTO");
                return OperationResultStatus.Failure;
            }
            var oldLandlord = await _landlordRepository.GetByIdAsync(dto.Id);
            if (oldLandlord == null)
            {
                _logger.LogWarning($"Landlord with id {dto.Id} not found for update");
                return OperationResultStatus.NotFound;
            }


            oldLandlord.Name = dto.Name;
            return await _landlordRepository.UpdateAsync(oldLandlord);
        }

        

    }
}
