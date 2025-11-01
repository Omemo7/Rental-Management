using Business.Application.Abstractions;
using Business.Application.Apartments.Commands;
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

        public async Task<Guid> Add(AddApartmentCommand cmd)
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

            await _apartmentRepo.Add(apartment);
            await _uow.SaveChanges();

            return apartment.Id;

        }

        public Task<bool> ChangeApartmentBuilding(Guid id, Guid buildingId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeApartmentSpecs(ChangeApartmentSpecsCommand cmd)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedResponse<Apartment>> GetAll(Guid landlordId, PaginatedQuery query)
        {
            throw new NotImplementedException();
        }

        public Task<Apartment?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
