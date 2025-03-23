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
       
    }
}
