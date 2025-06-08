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
using AutoMapper;
using Rental_Management.Business.DTOs.ApartmentBuilding;
using Rental_Management.DataAccess.Repositories;
using Rental_Management.Business.DTOs.Apartment;
using Rental_Management.Business.DTOs.Tenant;
using Shared.DTOs.ApartmentBuilding;
namespace Rental_Management.Business.Services
{
    public class LandlordService : BaseService<Landlord, LandlordDTO, AddLandlordDTO, UpdateLandlordDTO>, ILandlordService
    {

        ILandlordRepository _landlordRepository;
        public LandlordService(ILandlordRepository repository, ILogger<LandlordService> logger, IMapper mapper)
        : base(repository, logger, mapper) 
        {
            _landlordRepository = repository;
        }
        public async Task<ICollection<ApartmentDTO>> GetAllApartmentsForLandlord(int landlordId)
        {

            var apartments = await _landlordRepository.GetAllApartmentsForLandlord(landlordId);
            return _mapper.Map<ICollection<ApartmentDTO>>(apartments);

        }
        public async Task<ICollection<ApartmentBuildingDTO>> GetAllApartmentBuildingsForLandlord(int landlordId)
        {
            var buildings = await _landlordRepository.GetAllApartmentBuildingsForLandlord(landlordId);
            return _mapper.Map<ICollection<ApartmentBuildingDTO>>(buildings);
        }
        public async Task<ICollection<ApartmentBuildingIdAndNODTO>> GetAllApartmentBuildingsIdAndNOForLandlord(int landlordId)
        {
            var buildings = await _landlordRepository.GetAllApartmentBuildingsIdAndNOForLandlord(landlordId);
            return _mapper.Map<ICollection<ApartmentBuildingIdAndNODTO>>(buildings);
        }
        public async Task<ICollection<TenantDTO>> GetAllTenantsForLandlord(int landlordId)
        {
            var tenants = await _landlordRepository.GetAllTenantsForLandlord(landlordId);
            return _mapper.Map<ICollection<TenantDTO>>(tenants);
        }
    }
}
