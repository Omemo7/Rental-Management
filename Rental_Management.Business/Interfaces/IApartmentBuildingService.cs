using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental_Management.Business.DTOs.Apartment;
using Rental_Management.Business.DTOs.ApartmentBuilding;
using Shared;
namespace Rental_Management.Business.Interfaces
{
    public interface IApartmentBuildingService : IService<ApartmentBuildingDTO, AddApartmentBuildingDTO, UpdateApartmentBuildingDTO>
    {
        public Task<ICollection<ApartmentDTO>> GetAllApartmentsInBuilding(int apartmentBuildingId);
       
    }
}
