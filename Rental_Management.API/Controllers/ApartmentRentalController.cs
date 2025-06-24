using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Management.Business.DTOs.ApartmentRental;
using Rental_Management.Business.Interfaces;
using Shared.DTOs.ApartmentRental;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Rental_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentRentalController : BaseController<ApartmentRentalDTO, AddApartmentRentalDTO, UpdateApartmentRentalDTO>
    {
        IApartmentRentalService _apartmentRentalService;
        public ApartmentRentalController(IApartmentRentalService service) : base(service)
        {
            _apartmentRentalService = service;
        }
        [HttpGet("GetContractImagesByApartmentRentalId/{apartmentRentalId}")]
        public IActionResult GetContractImagesByApartmentRentalId(int apartmentRentalId)
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}";
            var wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var folderPath = Path.Combine(wwwRootPath, "ContractImages", apartmentRentalId.ToString());

            if (!Directory.Exists(folderPath))
                return NotFound("No contract images found for the specified apartment rental.");

            var fileNames = Directory.GetFiles(folderPath)
                .Select(Path.GetFileName)
                .ToList();

            var urls = fileNames
                .Select(file => $"{baseUrl}/ContractImages/{apartmentRentalId}/{file}")
                .ToList();

            if (!urls.Any())
                return NotFound("No contract images found for the specified apartment rental.");

            return Ok(urls);
        }


    }
}
