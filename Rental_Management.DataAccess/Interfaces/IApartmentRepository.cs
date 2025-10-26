using Rental_Management.DataAccess.Entities;

namespace Rental_Management.DataAccess.Interfaces;

public interface IApartmentRepository : IRepository<Apartment>
{
    Task<int> AddApartmentMaintenance(Maintenance entity);
    decimal GetApartmentTotalMaintenance(int apartmentId);
    decimal GetApartmentTotalPayments(int apartmentId);
}
