using AutoMapper;
using Microsoft.Extensions.Logging;
using Rental_Management.Business.DTOs.Apartment;
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
    public class ApartmentService : BaseService<Apartment, ApartmentDTO, AddApartmentDTO, UpdateApartmentDTO>, IApartmentService
    {

        IApartmentRepository _apartmentRepository;
        public ApartmentService(IApartmentRepository repository, ILogger<ApartmentService> logger, IMapper mapper)
        : base(repository, logger, mapper) 
        {
            _apartmentRepository = repository;
        }
       
        
    }
}
