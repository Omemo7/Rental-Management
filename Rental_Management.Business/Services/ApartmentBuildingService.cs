using AutoMapper;
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
    public class ApartmentBuildingService : BaseService<ApartmentBuilding,ApartmentBuildingDTO,AddApartmentBuildingDTO,UpdateApartmentBuildingDTO>,IApartmentBuildingService
    {
        readonly IApartmentBuildingRepository _apartmentBuildingRepository;
        

        public ApartmentBuildingService(IApartmentBuildingRepository apartmentBuildingRepository,ILogger<ApartmentBuildingService>logger
            ,IMapper mapper):
            base(apartmentBuildingRepository, logger,mapper)
        {
            _apartmentBuildingRepository = apartmentBuildingRepository;
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

       


    }
}
