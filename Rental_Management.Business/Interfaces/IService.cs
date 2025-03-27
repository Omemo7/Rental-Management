using Rental_Management.Business.DTOs.Landlord;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Interfaces
{
    public interface IService
    {
        Task<OperationResultStatus> AddAsync(object AddDTO);
        Task<OperationResultStatus> DeleteAsync(int Id);

        Task<OperationResultStatus> UpdateAsync(object UpdateDTO);

        Task<object?> GetByIdAsync(int id);
    }
}
