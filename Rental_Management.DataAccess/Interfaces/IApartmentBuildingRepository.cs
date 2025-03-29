using Microsoft.EntityFrameworkCore;
using Rental_Management.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.DataAccess.Interfaces
{
    public interface IApartmentBuildingRepository:IRepository<ApartmentBuilding>
    {
        public Task<ICollection<Apartment>> GetAllApartmentsInBuilding(int apartmentBuildingId);

       
    }
}
