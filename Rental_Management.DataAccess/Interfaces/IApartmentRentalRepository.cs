using Rental_Management.Business.DTOs.ApartmentRental;
using Rental_Management.DataAccess.Entities;
using Shared.DTOs.ApartmentRental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.DataAccess.Interfaces
{
    public interface IApartmentRentalRepository : IRepository<ApartmentsRental>
    {
        public Task<ApartmentRentalDTOForUI?> GetByIdAsyncForUI(int id);
        public Task<ICollection<ApartmentRentalDTOForUI>> GetAllApartmentRentalsForApartment(int apartmentId);
        public Task<ICollection<ApartmentRentalDTOForUI>> GetAllApartmentRentalsForLandlordForUI(int landlordId);

        public Task<ICollection<ApartmentRentalDTOForTenant>> GetAllApartmentRentalsForTenant(int tenantId);
    }
   
}
