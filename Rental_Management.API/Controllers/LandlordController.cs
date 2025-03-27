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
            OperationResultStatus result = await _landlordService.AddAsync(dto);
            switch (result)
            {
                case OperationResultStatus.Success: return Ok("Landlord added successfully.");
                case OperationResultStatus.Conflict: return Conflict("Landlord already exists.");
                default: return BadRequest("Failed to add landlord.");

            }

        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteLandlord(int landlordId)
        {
           
            OperationResultStatus result = await _landlordService.DeleteAsync(landlordId);
            switch (result)
            {
                case OperationResultStatus.Success: return Ok("Landlord deleted successfully.");
                case OperationResultStatus.NotFound: return NotFound("Landlord not found.");
                default: return BadRequest("Failed to delete landlord.");

            }
    
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateLandlord(UpdateLandlordDTO dto)
        {
            OperationResultStatus result = await _landlordService.UpdateAsync(dto);
            switch (result)
            {
                case OperationResultStatus.Success: return Ok("Landlord added successfully.");
                case OperationResultStatus.NotFound: return NotFound("Landlord not found.");
                default: return BadRequest("Failed to add landlord.");

            }
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetLandlordById(int id)
        {
            try
            {
                var landlord = await _landlordService.GetByIdAsync(id);
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
