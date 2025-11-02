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

        Task<Result<ApartmentSummary, Error>> IApartmentService.ChangeApartmentBuilding(Guid id, Guid buildingId)
        {
            throw new NotImplementedException();
        }

        Task<Result<ApartmentSummary, Error>> IApartmentService.ChangeApartmentSpecs(ChangeApartmentSpecsCommand cmd)
        {
            throw new NotImplementedException();
        }

        Task<PaginatedResponse<ApartmentSummary>> IApartmentService.GetAllAsync(Guid landlordId, PaginatedQuery query)
        {
            throw new NotImplementedException();
        }

        Task<Result<ApartmentSummary, Error>> IApartmentService.GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<Result<bool, Error>> IApartmentService.DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
