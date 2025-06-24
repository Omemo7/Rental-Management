using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Management.Business.DTOs.Apartment;
using Rental_Management.Business.DTOs.Landlord;
using Rental_Management.Business.Interfaces;
using Rental_Management.Business.Services;
using Shared;
using Shared.DTOs.Apartment;

namespace Rental_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : BaseController<ApartmentDTO, AddApartmentDTO, UpdateApartmentDTO>
    {

        private readonly IApartmentService _apartmentService;
        public ApartmentController(IApartmentService apartmentService):base(apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpPost("AddApartmentMaintenance")]
        public async Task<IActionResult> Add([FromBody] AddApartmentMaintenanceDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid input.");
            }

            int id = await _apartmentService.AddApartmentMaintenance(dto);

            if (id == -1)
            {
                return BadRequest("Failed to add entity.");
            }

            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        [HttpGet("GetApartmentTotalProfit/{apartmentId}")]
        public IActionResult GetApartmentTotalProfit(int apartmentId)
        {
            var totalProfit = _apartmentService.GetApartmentTotalProfit(apartmentId);
         
            return Ok(totalProfit);


        }

        }
}
