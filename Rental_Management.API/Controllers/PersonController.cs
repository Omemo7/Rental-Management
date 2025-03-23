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

        [HttpPost("Add")]
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
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeletePerson(int Id)
        {
            try
            {
                bool isDeleted = await _personService.DeletePersonAsync(Id);
                if (!isDeleted)
                    return BadRequest("Failed to delete person.");
                return Ok("Person deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonDTO dto)
        {
            try
            { 
                bool isUpdated = await _personService.UpdatePersonAsync(dto);
                if (!isUpdated)
                    return BadRequest("Failed to update person.");
                return Ok("Person updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetPersonById(int Id)
        {
            try
            {
                PersonDTO? person = await _personService.GetPersonByIdAsync(Id);
                if (person == null)
                    return NotFound("Person not found.");
                return Ok(person);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }

            [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPeople()
        {
            try
            {
                IEnumerable<PersonDTO> people = await _personService.GetAllPeopleAsync();
                return Ok(people);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex.Message);
            }
        }
    }
}
