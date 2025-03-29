using Microsoft.Extensions.Logging;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;
using Rental_Management.DataAccess.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.DataAccess.Repositories
{
    public class TenantRepository:Repository<Tenant>, ITenantRepository
    {
        public TenantRepository(ILogger<TenantRepository>logger,ApplicationDbContext context) : base(logger,context)
        {

        }
    }
}
