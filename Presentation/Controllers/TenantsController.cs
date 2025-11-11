using Business.Application.Tenants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Contracts.Tenants;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        public readonly ITenantService _tenantService;

        public TenantsController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpPost]
        public async Task<IActionResult> AddTenant([FromBody] AddTenantRequest req)
        {
            var result = await _tenantService.AddAsync(req.ToCommand());
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
            return CreatedAtAction(nameof(GetTenantById), new { id = result.Value }, result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTenantById(Guid id)
        {
            // Call the service to get the tenant by ID
            var result = await _tenantService.GetByIdAsync(id);
            if(!result.IsSuccess)
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
        public async Task<IActionResult> DeleteTenant(Guid id)
        {
            var result = await _tenantService.DeleteAsync(id);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTenant(Guid id, [FromBody] UpdateTenantRequest req)
        {
            var result = await _tenantService.UpdateAsync(req.ToCommand(id));
            if (!result.IsSuccess)
            {
                switch (result.Error.Type)
                {
                    case Business.Common.Errors.ErrorType.NotFound:
                        return NotFound(result.Error.Message);
                    case Business.Common.Errors.ErrorType.BadRequest:
                        return BadRequest(result.Error.Message);
                    default:
                        return StatusCode(500, result.Error.Message);
                }
            }
            return Ok(result.Value);
        }
    }
}
