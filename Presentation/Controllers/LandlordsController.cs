using Business.Application.Landlords;
using Business.Application.Landlords.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Contracts.Landlords;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class LandlordsController : ControllerBase
    {
        private readonly ILandlordService _landlordService;

        public LandlordsController(ILandlordService s) 
        {
            _landlordService = s;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddLandlordRequest req)
        {
            var cmd = new AddLandlordCommand
            {
                Email = req.Email,
                Password = req.Password,
                FirstName = req.FirstName,
                LastName = req.LastName
            };

            var id = await _landlordService.Add(cmd);
            return CreatedAtAction(nameof(GetById), new { id }, new { id });
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var landlord = await _landlordService.GetById(id);
            if (landlord is null) return NotFound();

            return Ok(landlord);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateLandlordRequest req)
        {
            var cmd = new UpdateLandlordCommand
            {
                FirstName = req.FirstName,
                LastName = req.LastName
            };
            var updated = await _landlordService.Update(id, cmd);
            if (!updated) return NotFound();
            return NoContent();
        }
    }
}





