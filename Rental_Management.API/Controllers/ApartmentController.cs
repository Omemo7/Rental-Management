using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Management.Business.DTOs.Apartment;
using Rental_Management.Business.Interfaces;
using Shared;

namespace Rental_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        IApartmentService _apartmentService;
        ILogger<ApartmentController> _logger;
        public ApartmentController(IApartmentService apartmentService, ILogger<ApartmentController> logger)
        {
            _apartmentService = apartmentService;
            _logger = logger;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> AddApartment(AddApartmentDTO dto)
        {
            OperationResultStatus result = await _apartmentService.AddAsync(dto);
            switch (result)
            {
                case OperationResultStatus.Success: return Ok("Apartment has been added successfully.");
                case OperationResultStatus.Conflict: return Conflict("Apartment already exists.");
                default: return BadRequest("Failed to add apartment.");
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteApartment(int id)
        {
            OperationResultStatus result = await _apartmentService.DeleteAsync(id);
            switch (result)
            {
                case OperationResultStatus.Success: return Ok("Apartment has been deleted successfully.");
                case OperationResultStatus.NotFound: return NotFound("Apartment not found.");
                default: return BadRequest("Failed to delete apartment.");
            }
        }
        [HttpGet("GetAllApartmentsForLandlord/{landlordId}")]
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
        [HttpGet("GetApartmentById/{id}")]
        public async Task<IActionResult> GetApartmentById(int id)
        {
            var apartment = await _apartmentService.GetByIdAsync(id);
            if (apartment == null) return NotFound("Apartment not found.");
            return Ok(apartment);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateApartment(UpdateApartmentDTO dto)
        {
            OperationResultStatus result = await _apartmentService.UpdateAsync(dto);
            switch (result)
            {
                case OperationResultStatus.Success: return Ok("Apartment has been updated successfully.");
                case OperationResultStatus.NotFound: return NotFound("Apartment not found.");
                default: return BadRequest("Failed to update apartment.");
            }
        }

    }
}
