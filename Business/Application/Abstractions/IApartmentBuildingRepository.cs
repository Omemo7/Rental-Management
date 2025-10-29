
using Rental_Management.Business.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Application.Abstractions
{
    public interface IApartmentBuildingRepository:IRepository<ApartmentBuilding>
    {
        public Task<ICollection<Apartment>> GetAllApartmentsInBuilding(int apartmentBuildingId);

       
    }
}
