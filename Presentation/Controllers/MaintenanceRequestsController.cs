using Business.Application.MaintenanceRequests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Contracts.MaintenanceRequests;
using RentalManagement.Business.Domain.ValueObjects;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceRequestsController : ControllerBase
    {
        IMaintenanceRequestService _maintenanceRequestService;
        public MaintenanceRequestsController(IMaintenanceRequestService maintenanceRequestService)
        {
            _maintenanceRequestService = maintenanceRequestService;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddMaintenanceRequestRequest req)
        {
            var result = await _maintenanceRequestService.AddAsync(req.ToCommand());
            if (!result.IsSuccess)
            {
                switch (result.Error.Type)
                {
                    case Business.Common.Errors.ErrorType.Validation:
                        return BadRequest(result.Error.Message);
                    default:
                        return StatusCode(500, result.Error.Message);
                }
            }
            return CreatedAtAction(nameof(GetById), new { id = result.Value }, result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _maintenanceRequestService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                switch (result.Error.Type)
                {
                    case Business.Common.Errors.ErrorType.NotFound:
                        return NotFound(result.Error.Message);
                    default:
                        return BadRequest(result.Error.Message);
                }
            }
            return Ok(result.Value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _maintenanceRequestService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                switch (result.Error.Type)
                {
                    case Business.Common.Errors.ErrorType.NotFound:
                        return NotFound(result.Error.Message);
                    default:
                        return BadRequest(result.Error.Message);
                }
            }
            return Ok(result.Value);
        }

        [HttpPut("{id}/schedule")]
        public async Task<IActionResult> Schedule(Guid id, [FromBody] DateTime when)
        {
            var result = await _maintenanceRequestService.ScheduleAsync(id, when);
            if (!result.IsSuccess)
            {
                switch (result.Error.Type)
                {
                    case Business.Common.Errors.ErrorType.NotFound:
                        return NotFound(result.Error.Message);
                    default:
                        return BadRequest(result.Error.Message);
                }
            }
            return Ok(result.Value);
        }
        [HttpPut("{id}/complete")]
        public async Task<IActionResult> Complete(Guid id, CompleteMaintenanceRequestRequest req)
        {
            var result = await _maintenanceRequestService.CompleteAsync(id, req.LaborCost,req.PartsCost);
            if (!result.IsSuccess)
            {
                switch (result.Error.Type)
                {
                    case Business.Common.Errors.ErrorType.NotFound:
                        return NotFound(result.Error.Message);
                    default:
                        return BadRequest(result.Error.Message);
                }
            }
            return Ok(result.Value);
        }
    }
}
