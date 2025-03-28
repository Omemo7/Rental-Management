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
            int id = await _landlordService.AddAsync(dto);

            if (id == -1)
            {
                return BadRequest("Failed to add landlord.");
            }

          
            return CreatedAtAction(nameof(GetLandlordById), new { id = id }, dto); 
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteLandlord(int id)
        {
           
            OperationResultStatus result = await _landlordService.DeleteAsync(id);
            switch (result)
            {
                case OperationResultStatus.Success: return Ok("Landlord deleted successfully.");
                case OperationResultStatus.NotFound: return NotFound("Landlord not found.");
                default: return BadRequest("Failed to delete landlord.");

            }
    
        }
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateLandlord(int id, UpdateLandlordDTO dto)
        {
           
            dto.Id = id;
            OperationResultStatus result = await _landlordService.UpdateAsync(dto);

            switch (result)
            {
                case OperationResultStatus.Success:
                    return Ok(await _landlordService.GetByIdAsync(id)); 
                case OperationResultStatus.NotFound:
                    return NotFound("Landlord not found.");
                default:
                    return BadRequest("Failed to update landlord.");
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetLandlordById(int id)
        {
            var landlord = await _landlordService.GetByIdAsync(id);
            if (landlord == null)
            {
                return NotFound();
            }
            return Ok(landlord);
        }


    }
}
