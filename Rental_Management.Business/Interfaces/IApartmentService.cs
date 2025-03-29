using Rental_Management.Business.DTOs.Apartment;
using Rental_Management.Business.DTOs.ApartmentBuilding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Interfaces
{
    public interface IApartmentService : IService<ApartmentDTO, AddApartmentDTO, UpdateApartmentDTO>    
    {
       
       
    }
}
