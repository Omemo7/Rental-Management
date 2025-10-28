using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Management.Business.Interfaces;
using System.Linq;

namespace Rental_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentPaymentFrequencyController : ControllerBase
    {
        private readonly IRentPaymentFrequencyService _rentPaymentFrequencyService;

        public RentPaymentFrequencyController(IRentPaymentFrequencyService rentPaymentFrequencyService)
        {
            _rentPaymentFrequencyService = rentPaymentFrequencyService;
        }

        [HttpGet("GetRentPaymentFrequenciesWithId")]
        public async Task<IActionResult> GetRentPaymentFrequenciesWithId()
        {
            try
            {
                var frequencies = await _rentPaymentFrequencyService.GetRentPaymentFrequenciesAsync();
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
