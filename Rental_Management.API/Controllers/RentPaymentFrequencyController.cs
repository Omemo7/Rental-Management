using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Management.Business.Services;

namespace Rental_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentPaymentFrequencyController : ControllerBase
    {
        [HttpGet("GetRentPaymentFrequenciesWithId")]
        public async Task<IActionResult> GetRentPaymentFrequenciesWithId()
        {
            try
            {
                var frequencies = await RentPaymentFrequencyService.GetRentPaymentFrequencies();
                if (frequencies == null || !frequencies.Any())
                    return NotFound("No frequencies found.");
                return Ok(frequencies);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
