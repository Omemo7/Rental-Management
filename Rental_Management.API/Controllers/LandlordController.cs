using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Management.Business.Services;
using Rental_Management.Business.Interfaces;
using Shared;
using System.Linq.Expressions;
using Rental_Management.DataAccess.Entities;
using Rental_Management.Business.DTOs.Landlord;
namespace Rental_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandlordController : BaseController< LandlordDTO, AddLandlordDTO, UpdateLandlordDTO>
    {

        public LandlordController(ILandlordService service) : base(service)
        {
        }

    }
}
