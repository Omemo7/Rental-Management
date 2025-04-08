using Rental_Management.DataAccess.Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.DataAccess.Interfaces
{
    public interface ITenantRepository : IRepository<Tenant>
    {
        public OperationResultStatus AddPhones(ICollection<string> phones, int tenantId);
        public ICollection<string> GetPhones(int tenantId);
    }
}
