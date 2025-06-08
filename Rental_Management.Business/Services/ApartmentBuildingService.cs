using AutoMapper;
using Microsoft.Extensions.Logging;
using Rental_Management.Business.DTOs.Apartment;
using Rental_Management.Business.DTOs.ApartmentBuilding;
using Rental_Management.Business.Interfaces;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;
using Rental_Management.DataAccess.Repositories;
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
        public async Task<ICollection<ApartmentDTO>> GetAllApartmentsInBuilding(int apartmentBuildingId)
        {
            var apartments = await _apartmentBuildingRepository.GetAllApartmentsInBuilding(apartmentBuildingId);
            return _mapper.Map<ICollection<ApartmentDTO>>(apartments);
        }

       


    }
}
