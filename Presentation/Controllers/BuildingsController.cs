using Business.Application.Buildings;
using Business.Application.Buildings.Commands;
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
            var buildingId = await _buildingService.AddAsync(command);
            return CreatedAtAction(nameof(GetBuildingById), new { id = buildingId }, null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBuildingById(Guid id)
        {
            var building = await _buildingService.GetByIdAsync(id);
            if (building == null) return NotFound();
            return Ok(building);
        }
    }
}
