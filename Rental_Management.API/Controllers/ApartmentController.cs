using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Management.Business.DTOs;
using Rental_Management.Business.Services;
using Rental_Management.Business.Interfaces;

namespace Rental_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService) 
        {
            _apartmentService = apartmentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddApartment([FromBody] AddApartmentDTO dto)
        {
            try
            {
                bool isAdded = await _apartmentService.AddApartmentAsync(dto);

                if (!isAdded)
                    return BadRequest("Failed to add apartment.");

                return Ok("Apartment added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

    }
}
