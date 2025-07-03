using Rental_Management.Business.DTOs.Apartment;
using Rental_Management.Business.DTOs.ApartmentBuilding;
using Rental_Management.Business.DTOs.ApartmentRental;
using Rental_Management.DataAccess.Entities;
using Shared.DTOs.Apartment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Interfaces
{
    public interface IApartmentService : IService<ApartmentDTO, AddApartmentDTO, UpdateApartmentDTO>    
    {

        Task<int> AddApartmentMaintenance(AddApartmentMaintenanceDTO dto);

        decimal GetApartmentTotalMaintenance(int apartmentId);
        decimal GetApartmentTotalProfit(int apartmentId);
    }
}
