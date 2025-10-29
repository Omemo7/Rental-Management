using Rental_Management.Business.DTOs.Apartment;
using Shared.DTOs.Apartment;

namespace Rental_Management.Business.Application.Abstractions;

public interface IApartmentService : IService<ApartmentDTO, AddApartmentDTO, UpdateApartmentDTO>
{
    Task<int> AddApartmentMaintenance(AddApartmentMaintenanceDTO dto);
    decimal GetApartmentTotalMaintenance(int apartmentId);
    decimal GetApartmentTotalProfit(int apartmentId);
}
