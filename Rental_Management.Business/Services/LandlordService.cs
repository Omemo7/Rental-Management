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
namespace Rental_Management.Business.Services
{
    public class LandlordService : BaseService<Landlord, LandlordDTO, AddLandlordDTO, UpdateLandlordDTO>, ILandlordService
    {


        public LandlordService(IRepository<Landlord> repository, ILogger<LandlordService> logger, IMapper mapper)
        : base(repository, logger, mapper) 
        {
 
        }
        


    }
}
