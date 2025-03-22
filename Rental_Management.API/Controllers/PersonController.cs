using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Management.Business.DTOs;
using Rental_Management.Business.Services;
using Rental_Management.Business.Interfaces;

namespace Rental_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] AddPersonDTO dto)
        {
            try
            {
                bool isAdded = await _personService.AddPersonAsync(dto);

                if (!isAdded)
                    return BadRequest("Failed to add person.");

                return Ok("Person added successfully.");
            }
            catch (Exception ex)
            { 
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }
    }
}
