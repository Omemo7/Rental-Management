using Business.Application.Landlords.Commands;
using Business.Application.Landlords.Summaries;
using Business.Common;
using Business.Common.Errors;
using RentalManagement.Business.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Application.Landlords
{
    public interface ILandlordService
    {
        public Task<Result<Guid,Error>> AddAsync(AddLandlordCommand cmd);
        public Task<Result<LandlordSummary,Error>> GetByIdAsync(Guid id);
        public Task<Result<LandlordSummary,Error>> UpdateAsync(UpdateLandlordCommand cmd);

    }
}
