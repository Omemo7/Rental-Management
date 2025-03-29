using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Management.Business.DTOs.Tenant;
using Rental_Management.Business.Interfaces;

namespace Rental_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantController : BaseController<TenantDTO,AddTenantDTO,UpdateTenantDTO>
    {
        ITenantService _service;
        public TenantController(ITenantService service) : base(service)
        {
            _service = service;
        }
    }
}
