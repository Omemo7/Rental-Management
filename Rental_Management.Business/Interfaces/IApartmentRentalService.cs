using Rental_Management.Business.DTOs.ApartmentRental;

namespace Rental_Management.Business.Interfaces;

public interface IApartmentRentalService : IService<ApartmentRentalDTO, AddApartmentRentalDTO, UpdateApartmentRentalDTO>
{
    Task<ICollection<ApartmentRentalDTOForUI>> GetAllApartmentRentalsForLandlordForUI(int landlordId);
    Task<ICollection<ApartmentRentalDTOForUI>> GetAllApartmentRentalsForApartment(int apartmentId);
    Task<ICollection<ApartmentRentalDTOForTenant>> GetAllApartmentRentalsForTenant(int tenantId);
    Task<ICollection<string>> GetContractImageUrlsAsync(int apartmentRentalId, string baseUrl);
}
