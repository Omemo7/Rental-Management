using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Management.Business.Services;
using Rental_Management.Business.Interfaces;
using Shared;
using System.Linq.Expressions;
using Rental_Management.DataAccess.Entities;
using Rental_Management.Business.DTOs.Landlord;
using Shared.DTOs.ApartmentBuilding;
namespace Rental_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandlordController : BaseController< LandlordDTO, AddLandlordDTO, UpdateLandlordDTO>
    {

        ILandlordService _landlordService;
        public LandlordController(ILandlordService service) : base(service)
        {
            _landlordService = service;
        }
       
        [HttpGet("GetAllApartmentBuildingsIdAndNOForLandlord/{landlordId}")]
        public async Task<IActionResult> GetAllApartmentBuildingsIdAndNOForLandlord(int landlordId)
        {
            try
            {
                var buildings = await _landlordService.GetAllApartmentBuildingsIdAndNOForLandlord(landlordId);
                if (buildings == null || !buildings.Any())
                    return NotFound("No apartment buildings found for landlord.");
                return Ok(buildings);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetAllApartmentBuildingsForLandlord/{landlordId}")]
        public async Task<IActionResult> GetAllApartmentBuildingsForLandlord(int landlordId)
        {
            try
            {
                var buildings = await _landlordService.GetAllApartmentBuildingsForLandlord(landlordId);
                if (buildings == null)
                    return NotFound("No apartment buildings found for landlord.");
                return Ok(buildings);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
        [HttpGet("GetAllApartmentsForLandlord/{landlordId}")]
        public async Task<IActionResult> GetAllApartmentsForLandlord(int landlordId)
        {

            var apartments = await _landlordService.GetAllApartmentsForLandlord(landlordId);
            return Ok(apartments);
        }

        [HttpGet("GetAllTenantsForLandlord/{landlordId}")]
        public async Task<IActionResult> GetAllTenantsForLandlord(int landlordId)
        {
            var tenants = await _landlordService.GetAllTenantsForLandlord(landlordId);
            return Ok(tenants);
        }

    }
}
