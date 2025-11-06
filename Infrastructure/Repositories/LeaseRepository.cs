using Business.Application.Abstractions;
using RentalManagement.Business.Domain.Entities;
using RentalManagement.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class LeaseRepository:Repository<Lease>,ILeaseRepository
    {
        
        public LeaseRepository(AppDbContext context) : base(context)
        {
        }
    }
}
