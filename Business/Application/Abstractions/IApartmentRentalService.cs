using Rental_Management.Business.DTOs.ApartmentRental;
using Shared.DTOs.ApartmentRental;

namespace Rental_Management.Business.Application.Abstractions;

public interface IApartmentRentalService : IService<ApartmentRentalDTO, AddApartmentRentalDTO, UpdateApartmentRentalDTO>
{
    Task<ICollection<ApartmentRentalDTOForUI>> GetAllApartmentRentalsForApartment(int apartmentId);
    Task<ICollection<ApartmentRentalDTOForUI>> GetAllApartmentRentalsForLandlordForUI(int landlordId);
    Task<ICollection<ApartmentRentalDTOForTenant>> GetAllApartmentRentalsForTenant(int tenantId);
    Task<ICollection<string>> GetContractImageUrlsAsync(int apartmentRentalId, string baseUrl);
}
