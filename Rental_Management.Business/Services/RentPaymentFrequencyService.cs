using Org.BouncyCastle.Pqc.Crypto.Lms;
using Rental_Management.DataAccess.Repositories;
using Shared.DTOs.RentPaymentFrequency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Services
{
    public static class RentPaymentFrequencyService
    {
        public static async Task<List<RentPaymentFrequencyWithIdDTO>> GetRentPaymentFrequencies()
        {
            return await RentPaymentFrequencyRepository.GetRentPaymentFrequeniesWithIds();
        }
    }
}
