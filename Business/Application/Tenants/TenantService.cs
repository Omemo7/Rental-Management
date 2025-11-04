using Business.Application.Abstractions;
using Business.Application.Tenants.Commands;
using Business.Application.Tenants.Summaries;
using Business.Common;
using Business.Common.Errors;
using RentalManagement.Business.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Application.Tenants
{
    public class TenantService : ITenantService
    {
        IUnitOfWork _uow;
        ITenantRepository _tenantRepository;
        public TenantService(IUnitOfWork uow, ITenantRepository tenantRepository)
        {
            _uow = uow;
            _tenantRepository = tenantRepository;
        }
        public async Task<Result<Guid, Error>> AddAsync(AddTenantCommand cmd)
        {
            Tenant tenant = new Tenant( Guid.NewGuid(),
                cmd.FirstName,
                cmd.LastName,
                cmd.Email,
                cmd.PhoneNumber);

            return await Util.ResultReturnHandler(tenant.Id, _uow, async () => await _tenantRepository.AddAsync(tenant));


        }

        public async Task<Result<bool, Error>> DeleteAsync(Guid tenantId)
        {
            var tenant = await _tenantRepository.GetByIdAsync(tenantId);
            if (tenant == null) return Error.NotFound($"Tenant with ID {tenantId} not found.");

            return await Util.ResultReturnHandler(true, _uow, async () => await _tenantRepository.DeleteAsync(tenantId));
        }

        public async Task<Result<TenantSummary, Error>> GetByIdAsync(Guid tenantId)
        {
            var tenant = await _tenantRepository.GetByIdAsync(tenantId);
            if (tenant == null) return Error.NotFound($"Tenant with ID {tenantId} not found.");

            return await Util.ResultReturnHandler(TenantSummary.FromTenant(tenant));

        }

        public async Task<Result<TenantSummary, Error>> UpdateAsync(Guid tenantId, UpdateTenantCommand cmd)
        {
            Tenant? tenant = await _tenantRepository.GetByIdAsync(tenantId);
            if (tenant == null) return Error.NotFound($"Tenant with ID {tenantId} not found.");

            tenant.ChangeFullName(cmd.FirstName, cmd.LastName);
            tenant.ChangeEmail(cmd.Email);
            tenant.ChangePhoneNumber(cmd.PhoneNumber);

            return await Util.ResultReturnHandler(TenantSummary.FromTenant(tenant), _uow, () => _tenantRepository.Update(tenant));
        }
    }
}
