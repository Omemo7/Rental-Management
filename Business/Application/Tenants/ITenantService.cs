using Business.Application.Tenants.Commands;
using Business.Application.Tenants.Summaries;
using Business.Common;
using Business.Common.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Application.Tenants
{
    public interface ITenantService
    {
        Task<Result<Guid,Error>> AddAsync(AddTenantCommand cmd);
        Task<Result<TenantSummary,Error>> GetByIdAsync(Guid tenantId);

        Task<Result<bool,Error>> DeleteAsync(Guid tenantId);
        Task<Result<TenantSummary,Error>> UpdateAsync(Guid tenantId, UpdateTenantCommand cmd);
    }
}
