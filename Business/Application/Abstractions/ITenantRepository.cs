using Rental_Management.Business.Domain.Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Application.Abstractions
{
    public interface ITenantRepository : IRepository<Tenant>
    {
        public OperationResultStatus AddPhones(ICollection<string> phones, int tenantId);
        public ICollection<string> GetPhones(int tenantId);
        public decimal GetTotalPaidAmount(int tenantId);
        public Task<bool> ClearPhones(int tenantId);
    }
}
