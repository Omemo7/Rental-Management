using Business.Application.Buildings.Commands;
using Business.Application.Buildings.Summaries;
using Business.Common;
using Business.Common.Errors;
using Business.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Application.Buildings
{
    public interface IBuildingService
    {
        public Task<Result<Guid,Error>> AddAsync(AddBuildingCommand cmd);
        public Task<Result<bool,Error>> RemoveAsync(Guid buildingId);
        public Task<Result<BuildingSummary,Error>> GetByIdAsync(Guid buildingId);
        public Task<Result<BuildingSummary,Error>> ChangeAddressAsync(ChangeAddressCommand cmd);

        public Task<Result<BuildingSummary,Error>> ChangeNameAsync(Guid buildingId, string newName);
        public Task<PaginatedResponse<BuildingSummary>> GetAllAsync(Guid LandlordId,PaginatedQuery query);
    }
}
