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
    public interface IApartmentService
    {
        public Task<Result<Guid,Error>> AddAsync(AddApartmentCommand cmd);
        public Task<Result<ApartmentSummary,Error>> GetByIdAsync(Guid id);
        public Task<Result<ApartmentSummary,Error>> RenameApartmentUnit(Guid id, string newUnitNumber);
        public Task<Result<ApartmentSummary,Error>> ChangeApartmentSpecs(ChangeApartmentSpecsCommand cmd);
        public Task<Result<ApartmentSummary,Error>> ChangeApartmentBuilding(Guid id,  Guid buildingId);
        public Task<Result<bool,Error>> DeleteAsync(Guid id);

        public Task<PaginatedResponse<ApartmentSummary>> GetAllAsync(Guid landlordId,PaginatedQuery query);
    }

   
}
