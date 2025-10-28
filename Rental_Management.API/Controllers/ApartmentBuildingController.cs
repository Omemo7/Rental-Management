using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Management.Business.DTOs.ApartmentBuilding;
using Rental_Management.Business.DTOs.Landlord;
using Rental_Management.Business.Interfaces;
using Rental_Management.Business.Services;
using Rental_Management.Business.Common;

namespace Rental_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentBuildingController :BaseController<ApartmentBuildingDTO, AddApartmentBuildingDTO, UpdateApartmentBuildingDTO>
    {

        private readonly IApartmentBuildingService _apartmentBuildingService;
       
        public ApartmentBuildingController(IApartmentBuildingService apartmentBuildingService):base(apartmentBuildingService)
        {
            _apartmentBuildingService = apartmentBuildingService;
            
        }

        [HttpGet("GetAllApartmentsInBuilding/{apartmentBuildingId}")]
        public async Task<IActionResult> GetAllApartmentsInBuilding(int apartmentBuildingId)
        {
            var apartments = await _apartmentBuildingService.GetAllApartmentsInBuilding(apartmentBuildingId);
            return Ok(apartments);
        }
    }
}
