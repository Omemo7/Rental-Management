using Rental_Management.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Interfaces
{
    public interface IApartmentService
    {

       Task<bool> AddApartmentAsync(AddApartmentDTO dto);
     
    }
}
