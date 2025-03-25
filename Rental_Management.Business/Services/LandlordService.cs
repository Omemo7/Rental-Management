using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental_Management.Business.Interfaces;
using Rental_Management.Business.DTOs;
using Rental_Management.DataAccess.Interfaces;
using Rental_Management.DataAccess.Entities;
using Microsoft.Identity.Client;
namespace Rental_Management.Business.Services
{
    public class LandlordService : ILandlordService
    {
        readonly IRepository<Landlord> _landlordRepository;
        
        public LandlordService(IRepository<Landlord> landlordRepository)
        {
            _landlordRepository = landlordRepository;
           
        }

        public async Task<bool> AddLandlordAsync(AddLandlordDTO dto)
        {
            bool landlordExists= await _landlordRepository.ExistsAsync(l => l.Username == dto.Username||
                                                                l.Email==dto.Email||
                                                                l.PhoneNumber==dto.PhoneNumber);
            
            if (landlordExists)
                return false;
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

        public async Task<bool> DeleteLandlordAsync(int landlordId)
        {
            return await _landlordRepository.DeleteAsync(landlordId);
        }

        public async Task<LandlordDTO?> GetLandlordByIdAsync(int id)
        {
            var landlord=await _landlordRepository.GetByIdAsync(id);
           
            if (landlord == null)
                return null;
            return new LandlordDTO
            {
                Username = landlord.Username,
                Name = landlord.Name,
                Email = landlord.Email,
                PhoneNumber = landlord.PhoneNumber,
            };
        }

        public async Task<bool> UpdateLandlordNameAsync(UpdateLandlordNameDTO dto)
        {
            var oldLandlord = await _landlordRepository.GetByIdAsync(dto.Id);
            if (oldLandlord == null)
                return false;

            oldLandlord.Name = dto.Name; // Modify only the necessary field
            return await _landlordRepository.UpdateAsync(oldLandlord);
        }

    }
}
