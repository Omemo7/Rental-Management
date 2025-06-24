using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Shared.DTOs.RentPaymentFrequency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.DataAccess.Repositories
{
    public static class RentPaymentFrequencyRepository
    {
        static ApplicationDbContext _context=new ApplicationDbContext();

        public async static Task<List<RentPaymentFrequencyWithIdDTO>> GetRentPaymentFrequeniesWithIds()
        {
           return await _context.RentPaymentFrequency
                .Select(x => new RentPaymentFrequencyWithIdDTO
                {
                    Id = x.Id,
                    Frequency = x.Frequency
                }).ToListAsync();
        }

    }
}
