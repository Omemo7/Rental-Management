using Rental_Management.Business.DTOs.Landlord;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Interfaces
{
    public interface IService<TDTO,TAddDTO,TUpdateDTO>
    {
        Task<int> AddAsync(TAddDTO AddDTO);
        Task<OperationResultStatus> DeleteAsync(int Id);

        Task<OperationResultStatus> UpdateAsync(TUpdateDTO UpdateDTO);

        Task<TDTO?> GetByIdAsync(int id);
    }
}
