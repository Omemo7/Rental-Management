using Rental_Management.Business.Common;
using Rental_Management.Business.Entities;
using Rental_Management.Business.DTOs.Tenant;
using System.Collections.Generic;

namespace Rental_Management.Business.Interfaces;

public interface ITenantService : IService<TenantDTO, AddTenantDTO, UpdateTenantDTO>
{
    OperationResultStatus AddPhones(ICollection<string> phones, int tenantId);
    ICollection<string> GetPhones(int tenantId);
    decimal GetTotalPaidAmount(int tenantId);
}
