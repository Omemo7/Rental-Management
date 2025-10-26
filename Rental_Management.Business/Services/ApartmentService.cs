using AutoMapper;
using Microsoft.Extensions.Logging;
using Rental_Management.Business.DTOs.Apartment;
using Rental_Management.Business.Interfaces;
using Rental_Management.DataAccess.Entities;
using Rental_Management.DataAccess.Interfaces;
using Shared;
using Shared.DTOs.Apartment;

namespace Rental_Management.Business.Services
{
    public class ApartmentService : BaseService<Apartment, ApartmentDTO, AddApartmentDTO, UpdateApartmentDTO>, IApartmentService
    {

        IApartmentRepository _apartmentRepository;
        public ApartmentService(IApartmentRepository repository, ILogger<ApartmentService> logger, IMapper mapper)
        : base(repository, logger, mapper) 
        {
            _apartmentRepository = repository;
        }

        public async Task<int> AddApartmentMaintenance(AddApartmentMaintenanceDTO dto)
        {
            Maintenance maintenance = new Maintenance
            {
                ApartmentId = dto.ApartmentId,
                Description = dto.Description,
                MaintenanceDate = dto.MaintenanceDate,
                Cost = dto.Cost
            };

            return await _apartmentRepository.AddApartmentMaintenance(maintenance);
        }
        public decimal GetApartmentTotalMaintenance(int apartmentId)
        {
            return _apartmentRepository.GetApartmentTotalMaintenance(apartmentId);
        }
        public decimal GetApartmentTotalProfit(int apartmentId)
        {
            var totalPayments = _apartmentRepository.GetApartmentTotalPayments(apartmentId);
            var totalMaintenance = _apartmentRepository.GetApartmentTotalMaintenance(apartmentId);
            return totalPayments - totalMaintenance;
        }
    }
}
