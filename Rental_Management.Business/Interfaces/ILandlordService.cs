using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental_Management.Business.DTOs;
using Shared;

namespace Rental_Management.Business.Interfaces
{
    public interface ILandlordService
    {
        Task<OperationResultStatus> AddLandlordAsync(AddLandlordDTO dto);
        Task<OperationResultStatus> DeleteLandlordAsync(int landlordId);

        Task<OperationResultStatus> UpdateLandlordNameAsync(UpdateLandlordNameDTO dto);

        Task<LandlordDTO?> GetLandlordByIdAsync(int id);

    }
}
