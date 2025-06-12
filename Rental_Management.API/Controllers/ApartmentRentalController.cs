using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental_Management.Business.DTOs.ApartmentRental;
using Rental_Management.Business.Interfaces;
using Shared.DTOs.ApartmentRental;
namespace Rental_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentRentalController : BaseController<ApartmentRentalDTO,AddApartmentRentalDTO,UpdateApartmentRentalDTO>
    {
        IApartmentRentalService _apartmentRentalService;
        public ApartmentRentalController(IApartmentRentalService service) : base(service)
        {
            _apartmentRentalService = service;
        }
    }
}
