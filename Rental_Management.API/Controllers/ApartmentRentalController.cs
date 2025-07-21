using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Management.Business.DTOs.ApartmentRental;
using Rental_Management.Business.Interfaces;
using Shared.DTOs.ApartmentRental;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Rental_Management.Business.Services;

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
        [HttpGet("GetAllApartmentRentalsForLandlordUI/{landlordId}")]
        public async Task<IActionResult> GetAllApartmentRentalsForLandlordUI(int landlordId)
        {
            try
            {
                var rentals = await _apartmentRentalService.GetAllApartmentRentalsForLandlordForUI(landlordId);
                if (rentals == null || !rentals.Any())
                    return NotFound("No apartment rentals found for landlord.");
                return Ok(rentals);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetAllApartmentRentalsForTenant/{tenantId}")]
        public async Task<IActionResult> GetAllApartmentRentalsForTenant(int tenantId)
        {
            try
            {
                var rentals = await _apartmentRentalService.GetAllApartmentRentalsForTenant(tenantId);
                if (rentals == null || !rentals.Any())
                    return NotFound("No apartment rentals found for tenant.");
                return Ok(rentals);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetAllApartmentRentalsForApartment/{apartmentId}")]
        public async Task<IActionResult> GetAllApartmentRentalsForApartment(int apartmentId)
        {
            try
            {
                var rentals = await _apartmentRentalService.GetAllApartmentRentalsForApartment(apartmentId);
                if (rentals == null || !rentals.Any())
                    return NotFound("No apartment rentals found for apartment.");
                return Ok(rentals);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
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
