using Rental_Management.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.DataAccess.Interfaces
{
    public interface ILandlordRepository : IRepository<Landlord>
    {
        public Task<ICollection<ApartmentBuilding>> GetAllApartmentBuildingsForLandlord(int landlordId);
        public Task<ICollection<Apartment>> GetAllApartmentsForLandlord(int landlordId);

        public Task<ICollection<Tenant>> GetAllTenantsForLandlord(int landlordId);

        public Task<ICollection<ApartmentsRental>> GetAllActiveApartmentRentalsForLandlord(int landlordId);
    }
}
