using Business.Application.Buildings.Commands;
using Business.Application.Buildings.Summaries;
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
        public Task<Guid> AddAsync(AddBuildingCommand cmd);
        public Task<bool> RemoveAsync(Guid buildingId);
        public Task<BuildingSummary?> GetByIdAsync(Guid buildingId);
        public Task<bool> ChangeAddressAsync(ChangeAddressCommand cmd);

        public Task<bool> ChangeNameAsync(Guid buildingId, string newName);
        public Task<PaginatedResponse<BuildingSummary>> GetAllAsync(Guid LandlordId,PaginatedQuery query);
    }
}
