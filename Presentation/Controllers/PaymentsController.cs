using Business.Application.Payments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Contracts.Payments;
using Presentation.Contracts.Tenants;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        IPaymentService _paymentService;
        public PaymentsController(IPaymentService ps)
        {
            _paymentService = ps;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddPaymentRequest req)
        {
            var result = await _paymentService.AddAsync(req.ToCommand());
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
            // Call the service to get the tenant by ID
            var result = await _paymentService.GetByIdAsync(id);
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
            var result = await _paymentService.DeleteAsync(id);
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
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePaymentRequest req)
        {
            var result = await _paymentService.UpdateAsync(req.ToCommand(id));
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
