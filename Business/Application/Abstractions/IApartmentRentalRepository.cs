using Rental_Management.Business.Domain.Entities;

namespace Rental_Management.Business.Application.Abstractions;

public interface IApartmentRentalRepository : IRepository<ApartmentsRental>
{
    Task<ICollection<ApartmentsRental>> GetAllForLandlordAsync(int landlordId);
    Task<ICollection<ApartmentsRental>> GetAllForApartmentAsync(int apartmentId);
    Task<ICollection<ApartmentsRental>> GetAllForTenantAsync(int tenantId);
    Task<ApartmentsRental?> GetByIdWithDetailsAsync(int id);
}
