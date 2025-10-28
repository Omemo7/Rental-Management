using Rental_Management.Business.Entities;
using Rental_Management.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Interfaces.Repositories
{
    public interface ITenantRepository : IRepository<Tenant>
    {
        public OperationResultStatus AddPhones(ICollection<string> phones, int tenantId);
        public ICollection<string> GetPhones(int tenantId);
        public decimal GetTotalPaidAmount(int tenantId);
        public Task<bool> ClearPhones(int tenantId);
    }
}
