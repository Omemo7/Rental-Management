using Business.Application.Leases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Contracts.Leases;
using RentalManagement.Business.Domain.Entities;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeasesController : ControllerBase
    {
        ILeaseService leaseService;

        public LeasesController(ILeaseService leaseService)
        {
            this.leaseService = leaseService;
        }

        [HttpPost]
        public async Task<IActionResult> AddLease([FromBody] AddLeaseRequest req)
        {
            var result = await leaseService.AddAsync(req.ToCommand());
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error.Message);
            }
            return CreatedAtAction(nameof(GetLease), new { id = result.Value }, result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLease(Guid id)
        {
            var result = await leaseService.GetByIdAsync(id);
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

        [HttpPut("{id}/terminate")]
        public async Task<IActionResult> TerminateLease(Guid id)
        {
            var result = await leaseService.TerminateLeaseAsync(id);
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

        [HttpPut("{id}/renew")]
        public async Task<IActionResult> RenewLease(Guid id, DateOnly newEndDate)
        {
            var result = await leaseService.RenewLeaseAsync(id, newEndDate);
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

        [HttpGet("{id}/isActive")]
        public async Task<IActionResult> IsActive(Guid id)
        {
            var result = await leaseService.IsActive(id);
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

        [HttpPut("{id}/changeRentAmount")]
        public async Task<IActionResult> ChangeRentAmount(Guid id, decimal newRentAmount)
        {
            var result = await leaseService.ChangeRentAmountAsync(id, newRentAmount);
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

        [HttpPut("{id}/changeLeaseDates")]
        public async Task<IActionResult> ChangeLeaseDates(Guid id, DateOnly newStartDate, DateOnly newEndDate)
        {
            var result = await leaseService.ChangeLeaseDatesAsync(id, newStartDate, newEndDate);
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
        [HttpPut("{id}/changeRentPaymentFrequency")]
        public async Task<IActionResult> ChangeRentPaymentFrequency(Guid id, RentPaymentFrequency freq)
        {
            var result = await leaseService.ChangeRentPaymentFrequency(id, freq);
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

        [HttpPut("{id}/changeDepositAmount")]
        public async Task<IActionResult> ChangeDepositAmount(Guid id, decimal newDepositAmount)
        {
            var result = await leaseService.ChangeDepositAmountAsync(id, newDepositAmount);
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


        [HttpPut("{id}/increaseRent")]
        public async Task<IActionResult> IncreaseRent(Guid id, decimal delta)
        {
            var result = await leaseService.IncreaseRentAsync(id, delta);
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
