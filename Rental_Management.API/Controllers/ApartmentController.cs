using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Management.Business.DTOs.Apartment;
using Rental_Management.Business.DTOs.Landlord;
using Rental_Management.Business.Interfaces;
using Rental_Management.Business.Services;
using Shared;

namespace Rental_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : BaseController<ApartmentDTO, AddApartmentDTO, UpdateApartmentDTO>
    {

        private readonly IApartmentService _apartmentService;
        public ApartmentController(IApartmentService apartmentService):base(apartmentService)
        {
            _apartmentService = apartmentService;
        }
       
        [HttpGet("GetAllForLandlord/{landlordId}")]
        public async Task<IActionResult> GetAllApartmentsForLandlord(int landlordId)
        {
            
            var apartments = await _apartmentService.GetAllApartmentsForLandlord(landlordId);
            return Ok(apartments);
        }
        [HttpGet("GetAllApartmentsInBuilding/{apartmentBuildingId}")]
        public async Task<IActionResult> GetAllApartmentsInBuilding(int apartmentBuildingId)
        {
            var apartments = await _apartmentService.GetAllApartmentsInBuilding(apartmentBuildingId);
            return Ok(apartments);
        }
        

        

    }
}
