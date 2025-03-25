using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental_Management.Business.DTOs;

namespace Rental_Management.Business.Interfaces
{
    public interface ILandlordService
    {
        Task<bool> AddLandlordAsync(AddLandlordDTO dto);
        Task<bool> DeleteLandlordAsync(int landlordId);

        Task<bool> UpdateLandlordNameAsync(UpdateLandlordNameDTO dto);

        Task<LandlordDTO?> GetLandlordByIdAsync(int id);

    }
}
