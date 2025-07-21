using Rental_Management.Business.DTOs.Tenant;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Interfaces
{
    public interface ITenantService:IService<TenantDTO,AddTenantDTO,UpdateTenantDTO>
    {
        public OperationResultStatus AddPhones(ICollection<string> phones, int tenantId);
        public decimal GetTotalPaidAmount(int tenantId);
        public ICollection<string> GetPhones(int tenantId);
    }
}
