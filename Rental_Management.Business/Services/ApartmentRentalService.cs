using AutoMapper;
using Microsoft.Extensions.Logging;
using Rental_Management.Business.DTOs.ApartmentRental;
using Rental_Management.Business.Interfaces;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;
using Rental_Management.DataAccess.Repositories;
using Shared.DTOs.ApartmentRental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Rental_Management.Business.Services
{
    public class ApartmentRentalService:BaseService<ApartmentsRental, ApartmentRentalDTO, AddApartmentRentalDTO, UpdateApartmentRentalDTO>,IApartmentRentalService
    {
        IApartmentRentalRepository apartmentRentalRepository;
        public ApartmentRentalService(IApartmentRentalRepository repository, ILogger<ApartmentRentalService> logger, IMapper mapper) 
            : base(repository, logger, mapper)
        {
            apartmentRentalRepository = repository;
        }

        public async Task<ICollection<ApartmentRentalDTOForUI>> GetAllApartmentRentalsForLandlordForUI(int landlordId)
        {

            return await apartmentRentalRepository.GetAllApartmentRentalsForLandlordForUI(landlordId);
        }

        public async Task<ICollection<ApartmentRentalDTOForUI>> GetAllApartmentRentalsForApartment(int apartmentId)
        {

            return await apartmentRentalRepository.GetAllApartmentRentalsForApartment(apartmentId);
        }





    }


}
