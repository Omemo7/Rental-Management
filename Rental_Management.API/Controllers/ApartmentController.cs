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
        public async Task<IActionResult> AddLandlord(AddApartmentDTO dto)
        {
            int id = await _apartmentService.AddAsync(dto);

            if (id == -1)
            {
                return BadRequest("Failed to add landlord.");
            }


            return CreatedAtAction(nameof(GetApartmentById), new { id = id }, dto);
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
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetApartmentById(int id)
        {
            var apartment = await _apartmentService.GetByIdAsync(id);
            if (apartment == null)
                return NotFound("Apartment not found.");
            return Ok(apartment);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateApartment(int id,UpdateApartmentDTO dto)
        {
            dto.Id = id;
            OperationResultStatus result = await _apartmentService.UpdateAsync(dto);
            switch (result)
            {
                case OperationResultStatus.Success: return Ok(await _apartmentService.GetByIdAsync(id));
                case OperationResultStatus.NotFound: return NotFound("Apartment not found.");
                default: return BadRequest("Failed to update apartment.");
            }
        }

    }
}
