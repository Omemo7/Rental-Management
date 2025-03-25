using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Management.Business.DTOs.ApartmentBuilding;
using Rental_Management.Business.Interfaces;
using Shared;

namespace Rental_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentBuildingController : ControllerBase
    {

        private readonly IApartmentBuildingService _apartmentBuildingService;
        readonly ILogger<ApartmentBuildingController> _logger;

        public ApartmentBuildingController(IApartmentBuildingService apartmentBuildingService,ILogger<ApartmentBuildingController> logger)
        {
            _apartmentBuildingService = apartmentBuildingService;
            _logger = logger;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddApartmentBuilding(AddApartmentBuildingDTO dto)
        {
            OperationResultStatus result = await _apartmentBuildingService.AddApartmentBuildingAsync(dto);
            switch (result)
            {
               
                case OperationResultStatus.Success: return Ok("Apartment building added successfully.");
                case OperationResultStatus.Conflict: return Conflict("Apartment building already exists.");
                default: return BadRequest("Failed to add apartment building.");
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteApartmentBuilding(int apartmentBuildingId)
        {
            OperationResultStatus result = await _apartmentBuildingService.DeleteApartmentBuildingAsync(apartmentBuildingId);
            switch (result)
            {
                case OperationResultStatus.Success: return Ok("Apartment building deleted successfully.");
                case OperationResultStatus.NotFound: return NotFound("Apartment building not found.");
                default: return BadRequest("Failed to delete apartment building.");
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateApartmentBuilding(UpdateApartmentBuildingDTO dto)
        {
            OperationResultStatus result = await _apartmentBuildingService.UpdateApartmentBuildingAsync(dto);
            switch (result)
            {
                case OperationResultStatus.Success: return Ok("Apartment building updated successfully.");
                case OperationResultStatus.NotFound: return NotFound("Apartment building not found.");
                default: return BadRequest("Failed to update apartment building.");
            }
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetApartmentBuildingById(int id)
        {
            var apartmentBuilding = await _apartmentBuildingService.GetApartmentBuildingByIdAsync(id);
            if (apartmentBuilding == null)
                return NotFound("Apartment building not found.");
            return Ok(apartmentBuilding);
        }
        [HttpGet("GetAllForLandlord")]
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
                _logger.LogError($"Exception Message: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
           
        }
    }
}
