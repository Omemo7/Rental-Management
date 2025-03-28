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
            int id = await _apartmentBuildingService.AddAsync(dto);

            if (id == -1)
            {
                return BadRequest("Failed to add landlord.");
            }


            return CreatedAtAction(nameof(GetApartmentBuildingById), new { id }, dto);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteApartmentBuilding(int id)
        {
            OperationResultStatus result = await _apartmentBuildingService.DeleteAsync(id);
            switch (result)
            {
                case OperationResultStatus.Success: return Ok("Apartment building deleted successfully.");
                case OperationResultStatus.NotFound: return NotFound("Apartment building not found.");
                default: return BadRequest("Failed to delete apartment building.");
            }
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateApartmentBuilding(int id,UpdateApartmentBuildingDTO dto)
        {
            dto.Id = id;
            OperationResultStatus result = await _apartmentBuildingService.UpdateAsync(dto);
            switch (result)
            {
                case OperationResultStatus.Success: return Ok(await _apartmentBuildingService.GetByIdAsync(id));
                case OperationResultStatus.NotFound: return NotFound("Apartment building not found.");
                default: return BadRequest("Failed to update apartment building.");
            }
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetApartmentBuildingById(int id)
        {
            var apartmentBuilding = await _apartmentBuildingService.GetByIdAsync(id);
            if (apartmentBuilding == null)
                return NotFound("Apartment building not found.");
            return Ok(apartmentBuilding);
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
                _logger.LogError($"Exception Message: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
           
        }
    }
}
