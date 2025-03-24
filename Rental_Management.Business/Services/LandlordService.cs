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
            //var person= await _personRepository.GetByIdAsync(dto.PersonId);
            //if (person == null)
                return false;
          

            Landlord landlord = new Landlord
            { 
               
                Username = dto.Username,
                Password = dto.Password
            };

            return await _landlordRepository.AddAsync(landlord);

        }
    }
}
