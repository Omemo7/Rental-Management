using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental_Management.DataAccess.Repositories;
using Rental_Management.DataAccess.Interfaces;
using Rental_Management.DataAccess.Entities;
using Rental_Management.Business.DTOs;
using Rental_Management.Business.Interfaces;

namespace Rental_Management.Business.Services
{
    public class ApartmentService:IApartmentService
    {
        readonly IRepository<Apartment> _apartmentRepository;
        readonly IRepository<Landlord> _landlordRepository;

        public ApartmentService(IRepository<Apartment> apartmentRepository,IRepository<Landlord> landlordRepository)
        {
            _apartmentRepository = apartmentRepository;
            _landlordRepository = landlordRepository;
        }

        public async Task<bool> AddApartmentAsync(AddApartmentDTO dto)
        {
            if (dto == null)
                return false;

            var landlord = await _landlordRepository.GetByIdAsync(dto.LandLordId);
            if (landlord == null)
                return false; 

            Apartment apartment = new Apartment
            {
                StreetAddress = dto.StreetAddress,
                Neighborhood = dto.Neighborhood,
                City = dto.City,
                FloorNumber = dto.FloorNumber,
                Type = dto.Type,
                BuildingNumber = dto.BuildingNumber,
                SquaredMeters = dto.SquaredMeters,
                LandLordId = dto.LandLordId
            };
            return await _apartmentRepository.AddAsync(apartment);

        }

    }
}
