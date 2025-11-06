using Business.Application.Buildings;
using Business.Application.Buildings.Commands;
using Business.Common.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Contracts.Buildings;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        private readonly IBuildingService _buildingService;

        public BuildingsController(IBuildingService buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBuilding([FromForm] AddBuildingRequest req)
        {

            
            var result = await _buildingService.AddAsync(req.ToCommand());

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error.Message);
            }

            return CreatedAtAction(nameof(GetBuildingById),
                new { id = result.Value },
                null);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetBuildingById(Guid id)
        {
            var result = await _buildingService.GetByIdAsync(id);

            if (!result.IsSuccess)
            {
                return result.Error.Type switch
                {
                    ErrorType.NotFound => NotFound(result.Error.Message),
                    _ => BadRequest(result.Error.Message)
                };
            }

            return Ok(result.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeBuildingAddress(Guid id, [FromForm] ChangeAddressRequest req)
        {
           
            var result = await _buildingService.ChangeAddressAsync(req.ToCommand(id));

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error.Message);
            }

            return Ok(result.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuilding(Guid id)
        {
            var result = await _buildingService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                switch (result.Error.Type)
                {
                    case ErrorType.NotFound:
                        return NotFound(result.Error.Message);
                    default:
                        return BadRequest(result.Error.Message);
                }
            }
            return NoContent();
        }
    }
}
