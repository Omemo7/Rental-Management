using Rental_Management.Business.Entities;

namespace Rental_Management.Business.Interfaces.Repositories;

public interface IApartmentRepository : IRepository<Apartment>
{
    Task<int> AddApartmentMaintenance(Maintenance entity);
    decimal GetApartmentTotalMaintenance(int apartmentId);
    decimal GetApartmentTotalPayments(int apartmentId);
}
