using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Management.Business.DTOs.ApartmentBuilding;
using Rental_Management.Business.DTOs.Landlord;
using Rental_Management.Business.Interfaces;
using Rental_Management.Business.Services;
using Shared;

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
        
        [HttpGet("GetAllForLandlord/{landlordId}")]
        public async Task<IActionResult> GetAllApartmentBuildingsForLandlord(int landlordId)
        {
            try
            {
                var buildings = await _apartmentBuildingService.GetAllApartmentBuildingsForLandlord(landlordId);
                if (buildings == null)
                    return NotFound("No apartment buildings found for landlord.");
                return Ok(buildings);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
           
        }
    }
}
