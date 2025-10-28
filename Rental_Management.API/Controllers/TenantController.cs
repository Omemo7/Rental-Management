using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Management.Business.DTOs.Tenant;
using Rental_Management.Business.Interfaces;
using Rental_Management.Business.Common;

namespace Rental_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : BaseController<TenantDTO, AddTenantDTO, UpdateTenantDTO>
    {
        ITenantService _service;
        public TenantController(ITenantService service) : base(service)
        {
            _service = service;
        }
        [HttpPost("AddPhones/{tenantId}")]
        public IActionResult AddPhones([FromBody] ICollection<string> phones, int tenantId)
        {
            if (phones == null || tenantId <= 0)
            {
                return BadRequest("Invalid input.");
            }
            var result = _service.AddPhones(phones, tenantId);
            if (result == OperationResultStatus.Failure)
            {
                return BadRequest();
            }
            if (result == OperationResultStatus.NotFound)
            {
                return NotFound("Tenant not found.");
            }
            return Ok(phones);
        }


        
        [HttpGet("GetTotalPaidAmount/{tenantId}")]
        public IActionResult GetTotalPaidAmount(int tenantId)
        {
            if (tenantId <= 0)
            {
                return BadRequest("Invalid tenant ID.");
            }
            var totalPaidAmount = _service.GetTotalPaidAmount(tenantId);
            if (totalPaidAmount < 0)
            {
                return NotFound("Tenant not found");
            }
            return Ok(totalPaidAmount);
        }
        [HttpGet("GetPhones/{tenantId}")]
        public IActionResult GetPhones(int tenantId)
        {
            if (tenantId <= 0)
            {
                return BadRequest("Invalid input.");
            }
            var phones = _service.GetPhones(tenantId);
            if (phones == null || phones.Count == 0)
            {
                return NotFound("No phones found for this tenant.");
            }
            return Ok(phones);
        }
    }
}
