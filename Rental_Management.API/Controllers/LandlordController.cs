using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Management.Business.DTOs;
using Rental_Management.Business.Services;
using Rental_Management.Business.Interfaces;
namespace Rental_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandlordController : ControllerBase
    {
        private readonly ILandlordService _landlordService;

        public LandlordController(ILandlordService landlordService)
        {
            _landlordService = landlordService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddLandlord(AddLandlordDTO dto)
        {
            try
            {
                bool isAdded = await _landlordService.AddLandlordAsync(dto);

                if (!isAdded)
                    return BadRequest("Failed to add landlord.");

                return Ok("Landlord added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteLandlord(int landlordId)
        {
            try
            {
                bool isDeleted = await _landlordService.DeleteLandlordAsync(landlordId);
                if (!isDeleted)
                    return BadRequest("Failed to delete landlord.");
                return Ok("Landlord deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateLandlord(UpdateLandlordNameDTO dto)
        {
            try
            {
                bool isUpdated = await _landlordService.UpdateLandlordNameAsync(dto);
                if (!isUpdated)
                    return BadRequest("Failed to update landlord.");
                return Ok("Landlord updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetLandlordById(int id)
        {
            try
            {
                var landlord = await _landlordService.GetLandlordByIdAsync(id);
                if (landlord == null)
                    return NotFound("Landlord not found.");
                return Ok(landlord);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

    }
}
