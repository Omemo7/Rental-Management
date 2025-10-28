using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Management.Business.Interfaces;
using Rental_Management.Business.Services;
using Rental_Management.Business.Common;

namespace Rental_Management.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<TDTO, TAddDTO, TUpdateDTO> : ControllerBase
    {
        private readonly IService<TDTO, TAddDTO, TUpdateDTO> _service;

        
        public BaseController(IService<TDTO, TAddDTO, TUpdateDTO> service)
        {
            _service = service;
        }

        
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] TAddDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid input.");
            }

            int id = await _service.AddAsync(dto);

            if (id == -1)
            {
                return BadRequest("Failed to add entity.");
            }

            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound("Entity not found.");
            }
            return Ok(entity);
        }

       
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TUpdateDTO dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid input.");
            }

            dto.GetType().GetProperty("Id")?.SetValue(dto, id);
            var result = await _service.UpdateAsync(dto);
            if (result == OperationResultStatus.NotFound)
            {
                return NotFound("Entity not found.");
            }

            return result == OperationResultStatus.Success ? Ok(dto) : BadRequest("Failed to update entity.");
        }

       
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (result == OperationResultStatus.NotFound)
            {
                return NotFound("Entity not found.");
            }

            return result == OperationResultStatus.Success ? Ok("Entity deleted successfully.") : BadRequest("Failed to delete entity.");
        }
    }

}
