using Business.Application.Buildings;
using Business.Application.Buildings.Commands;
using Business.Common.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> AddBuilding([FromForm] AddBuildingCommand command)
        {
            var result = await _buildingService.AddAsync(command);

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
                return result.Error switch
                {
                    NotFoundError n => NotFound(n.Message),
                    _ => BadRequest(result.Error.Message)
                };
            }

            return Ok(result.Value);
        }

    }
}
