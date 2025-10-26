using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Management.Business.DTOs.ApartmentRental;
using Rental_Management.Business.Interfaces;
using Shared.DTOs.ApartmentRental;
using System.Linq;

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
        public async Task<IActionResult> GetContractImagesByApartmentRentalId(int apartmentRentalId)
        {
            try
            {
                var baseUrl = $"{Request.Scheme}://{Request.Host}";
                var urls = await _apartmentRentalService.GetContractImageUrlsAsync(apartmentRentalId, baseUrl);

                if (urls == null || !urls.Any())
                    return NotFound("No contract images found for the specified apartment rental.");

                return Ok(urls);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}
