using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental_Management.Business.DTOs;

namespace Rental_Management.Business.Interfaces
{
    public interface IPersonService
    {
        Task<bool> AddPersonAsync(AddPersonDTO dto);
        
    }
}
