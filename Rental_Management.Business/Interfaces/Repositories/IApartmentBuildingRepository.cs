using Rental_Management.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Interfaces.Repositories
{
    public interface IApartmentBuildingRepository:IRepository<ApartmentBuilding>
    {
        public Task<ICollection<Apartment>> GetAllApartmentsInBuilding(int apartmentBuildingId);

       
    }
}
