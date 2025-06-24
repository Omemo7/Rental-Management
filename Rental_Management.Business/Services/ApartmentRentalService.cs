using AutoMapper;
using Microsoft.Extensions.Logging;
using Rental_Management.Business.DTOs.ApartmentRental;
using Rental_Management.Business.Interfaces;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;
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

        public ApartmentRentalService(IApartmentRentalRepository repository, ILogger<ApartmentRentalService> logger, IMapper mapper) 
            : base(repository, logger, mapper)
        {

        }

       



    }


}
