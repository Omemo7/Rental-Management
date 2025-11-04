using Business.Application.Apartments;
using Business.Application.Apartments.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Contracts.Apartments;
using System.Security.Cryptography;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
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
        public async Task<IActionResult> AddApartment(AddApartmentRequest request)
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

            var result = await _apartmentService.AddAsync(cmd);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error.Message);
            }

            return Ok(result.Value);
        }
        [HttpPut("{apartmentId}/change-building/{newBuildingId}")]
        public async Task<IActionResult> ChangeApartmentBuilding(Guid apartmentId, Guid newBuildingId)
        {
            var result = await _apartmentService.ChangeApartmentBuilding(apartmentId, newBuildingId);
            if (!result.IsSuccess)
            {
                switch(result.Error.Type)
                {
                    case Business.Common.Errors.ErrorType.NotFound:
                        return NotFound(result.Error.Message);
                    default:
                        return BadRequest(result.Error.Message);
                }
                
            }
            return Ok(result.Value);
        }

        [HttpPut("{Id}/change-specs")]
        public async Task<IActionResult> ChangeApartmentSpecs(Guid Id, ChangeApartmentSpecsRequest request)
        {
            var cmd = new ChangeApartmentSpecsCommand
            {
                Id = Id,
                Bedrooms = request.Bedrooms,
                Bathrooms = request.Bathrooms,
                AreaSqm = request.AreaSqm
            };

            var result = await _apartmentService.ChangeApartmentSpecs(cmd);
            if (!result.IsSuccess)
            {
                switch(result.Error.Type)
                {
                    case Business.Common.Errors.ErrorType.NotFound:
                        return NotFound(result.Error.Message);
                    default:
                        return BadRequest(result.Error.Message);
                }

            }
            return Ok(result.Value);
        }
        [HttpPut("{Id}/rename-unit")]
        public async Task<IActionResult> RenameApartmentUnit(Guid Id, string newUnitNumber)
        {
            var result = await _apartmentService.RenameApartmentUnit(Id, newUnitNumber);
            if (!result.IsSuccess)
            {
                switch(result.Error.Type)
                {
                    case Business.Common.Errors.ErrorType.NotFound:
                        return NotFound(result.Error.Message);
                    default:
                        return BadRequest(result.Error.Message);
                }
            }
            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApartmentById(Guid id)
        {
            var result = await _apartmentService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                switch(result.Error.Type)
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
        public async Task<IActionResult> DeleteApartment(Guid id)
        {
            var result = await _apartmentService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                switch(result.Error.Type)
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
