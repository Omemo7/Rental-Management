using Rental_Management.Business.Domain.Entities;

namespace Rental_Management.Business.Application.Abstractions;

public interface ILandlordRepository : IRepository<Landlord>
{
    Task<ICollection<ApartmentBuilding>> GetAllApartmentBuildingsForLandlord(int landlordId);
    Task<ICollection<Apartment>> GetAllApartmentsForLandlord(int landlordId);
    Task<ICollection<Tenant>> GetAllTenantsForLandlord(int landlordId);
    Task<ICollection<ApartmentsRental>> GetAllVacantApartmentRentalsForLandlord(int landlordId);
}
