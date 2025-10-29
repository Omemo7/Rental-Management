using Rental_Management.Business.Domain.Entities;

namespace Rental_Management.Business.Application.Abstractions;

public interface IApartmentRepository : IRepository<Apartment>
{
    Task<int> AddApartmentMaintenance(Maintenance entity);
    decimal GetApartmentTotalMaintenance(int apartmentId);
    decimal GetApartmentTotalPayments(int apartmentId);
}
