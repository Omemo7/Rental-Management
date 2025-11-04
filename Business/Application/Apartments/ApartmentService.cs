using Business.Application.Abstractions;
using Business.Application.Apartments.Commands;
using Business.Application.Apartments.Summaries;
using Business.Common;
using Business.Common.Errors;
using Business.Common.Pagination;
using RentalManagement.Business.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Application.Apartments
{
    public class ApartmentService:IApartmentService
    {
        IApartmentRepository _apartmentRepo;
        IUnitOfWork _uow;
        public ApartmentService(IApartmentRepository repo,IUnitOfWork uow)
        {
            _apartmentRepo = repo;
            _uow = uow;
        }

       

        public async Task<Result<Guid, Error>> AddAsync(AddApartmentCommand cmd)
        {
            var apartment = new Apartment(
    id: Guid.NewGuid(),
    buildingId: cmd.BuildingId,
    landlordId: cmd.LandlordId,
    unitNumber: cmd.UnitNumber,
    bedrooms: cmd.Bedrooms,
    bathrooms: cmd.Bathrooms,
    areaSqm: cmd.AreaSqm
);


            
            return await Util.ResultReturnHandler(apartment.Id, _uow, async () =>
            {
                await _apartmentRepo.AddAsync(apartment);
            });
        }

        public async Task<Result<ApartmentSummary, Error>> ChangeApartmentBuilding(Guid id, Guid buildingId)
        {
            Apartment? apartment = await _apartmentRepo.GetByIdAsync(id);
            if (apartment == null)
            {
                return Error.NotFound($"Apartment with ID {id} not found.");
            }
            if(apartment.BuildingId==buildingId)
            {
                return Error.BadRequest("The new building ID is the same as the current one.");
            }


            apartment.ChangeBuilding(buildingId);

            return await Util.ResultReturnHandler(ApartmentSummary.FromApartment(apartment), _uow,()=>
            {
                _apartmentRepo.Update(apartment);
            });
        }

        public async Task<Result<ApartmentSummary, Error>> ChangeApartmentSpecs(ChangeApartmentSpecsCommand cmd)
        {
            Apartment? apartment = await _apartmentRepo.GetByIdAsync(cmd.Id);
            if (apartment == null)
            {
                return Error.NotFound($"Apartment with ID {cmd.Id} not found.");
            }

            apartment.ChangeSpecs(cmd.Bedrooms, cmd.Bathrooms, cmd.AreaSqm);

            return await Util.ResultReturnHandler(ApartmentSummary.FromApartment(apartment), _uow, () =>
            {
                _apartmentRepo.Update(apartment);
            });
        }

        public async Task<Result<ApartmentSummary, Error>> RenameApartmentUnit(Guid id, string newUnitNumber)
        {
            Apartment? apartment = await _apartmentRepo.GetByIdAsync(id);
            if (apartment == null)
            {
                return Error.NotFound($"Apartment with ID {id} not found.");
            }

            apartment.RenameUnit(newUnitNumber);

            return await Util.ResultReturnHandler(ApartmentSummary.FromApartment(apartment), _uow, () =>
            {
                _apartmentRepo.Update(apartment);
            }); 
        }

        Task<PaginatedResponse<ApartmentSummary>> IApartmentService.GetAllAsync(Guid landlordId, PaginatedQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<ApartmentSummary, Error>> GetByIdAsync(Guid id)
        {
            var apartment=await _apartmentRepo.GetByIdAsync(id);
            if (apartment==null)
            {
                return Error.NotFound($"Apartment with ID {id} not found.");
            }

            return await Util.ResultReturnHandler(ApartmentSummary.FromApartment(apartment));


        }

        public async Task<Result<bool, Error>> DeleteAsync(Guid id)
        {
            var apartment = await _apartmentRepo.GetByIdAsync(id);
            if (apartment == null)
            {
                return Error.NotFound($"Apartment with ID {id} not found.");
            }

            return await Util.ResultReturnHandler(true, _uow, async () =>
            {
                await _apartmentRepo.DeleteAsync(id);
            });
        }

       
    }
}
