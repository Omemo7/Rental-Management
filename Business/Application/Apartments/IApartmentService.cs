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
    public interface IApartmentService
    {
        public Task<Guid> Add(AddApartmentCommand cmd);
        public Task<Apartment?> GetById(Guid id);
        public Task<bool> ChangeApartmentSpecs(ChangeApartmentSpecsCommand cmd);
        public Task<bool> ChangeApartmentBuilding(Guid id,  Guid buildingId);
        public Task<bool> Remove(Guid id);

        public Task<PaginatedResponse<Apartment>> GetAll(Guid landlordId,PaginatedQuery query);
    }

   
}
