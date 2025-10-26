using AutoMapper;
using Microsoft.Extensions.Logging;
using Rental_Management.Business.DTOs.Apartment;
using Rental_Management.Business.DTOs.ApartmentBuilding;
using Rental_Management.Business.DTOs.Landlord;
using Rental_Management.Business.DTOs.Tenant;
using Rental_Management.Business.Interfaces;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;
using Shared.DTOs.Apartment;
using Shared.DTOs.ApartmentBuilding;
using Shared.DTOs.Tenant;
using System.Linq;

namespace Rental_Management.Business.Services;

public class LandlordService : BaseService<Landlord, LandlordDTO, AddLandlordDTO, UpdateLandlordDTO>, ILandlordService
{
    private readonly ILandlordRepository _landlordRepository;

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
        var buildings = await _landlordRepository.GetAllApartmentBuildingsForLandlord(landlordId);
        return buildings
            .Select(building => new ApartmentBuildingIdAndNODTO
            {
                Id = building.Id,
                NO = building.BuildingNumber
            })
            .ToList();
    }

    public async Task<ICollection<TenantDTO>> GetAllTenantsForLandlord(int landlordId)
    {
        var tenants = await _landlordRepository.GetAllTenantsForLandlord(landlordId);
        return _mapper.Map<ICollection<TenantDTO>>(tenants);
    }

    public async Task<ICollection<ApartmentIdAndNameDTO>> GetAllApartmentsIdAndNameForLandlord(int landlordId)
    {
        var apartments = await _landlordRepository.GetAllApartmentsForLandlord(landlordId);
        return apartments
            .Select(apartment => new ApartmentIdAndNameDTO
            {
                Id = apartment.Id,
                Name = apartment.Name
            })
            .ToList();
    }

    public async Task<ICollection<TenantIdAndNameDTO>> GetAllTenantsIdAndNameForLandlord(int landlordId)
    {
        var tenants = await _landlordRepository.GetAllTenantsForLandlord(landlordId);
        return tenants
            .Select(tenant => new TenantIdAndNameDTO
            {
                Id = tenant.Id,
                Name = tenant.Name
            })
            .ToList();
    }
}
