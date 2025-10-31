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
    public class LandlordRepository :Repository<Landlord>, ILandlordRepository
    {
        AppDbContext _db;
        public LandlordRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
       
    }
}
