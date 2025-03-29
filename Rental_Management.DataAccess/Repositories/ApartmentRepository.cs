using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.DataAccess.Repositories
{
    public class ApartmentRepository:Repository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(ILogger<Repository<Apartment>> logger, ApplicationDbContext context) : base(logger, context)
        {
        }

       
    }
    
}
