using Rental_Management.Business.DTOs.ApartmentRental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Interfaces
{
    public interface IApartmentRentalService:IService<ApartmentRentalDTO, AddApartmentRentalDTO, UpdateApartmentRentalDTO>
    {
    }
}
