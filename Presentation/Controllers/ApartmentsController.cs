using Business.Application.Apartments;
using Business.Application.Apartments.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Contracts.Apartments;
using System.Security.Cryptography;
namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentsController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddApartmentRequest request)
        {
            var cmd = new AddApartmentCommand
            {
                BuildingId = request.BuildingId,
                LandlordId = request.LandlordId,
                UnitNumber = request.UnitNumber,
                Bedrooms = request.Bedrooms,
                Bathrooms = request.Bathrooms,
                AreaSqm = request.AreaSqm
            };

            await _apartmentService.Add(cmd);
            return Ok("Apartment created successfully.");
        }
    }
}
