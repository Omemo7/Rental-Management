using Rental_Management.Business.DTOs.Tenant;
using Rental_Management.Business.Domain.Entities;
using Rental_Management.Business.Application.Abstractions;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Application.Abstractions
{
    public interface ITenantService:IService<TenantDTO,AddTenantDTO,UpdateTenantDTO>
    {
        public OperationResultStatus AddPhones(ICollection<string> phones, int tenantId);
        public decimal GetTotalPaidAmount(int tenantId);
        public ICollection<string> GetPhones(int tenantId);
    }
}
