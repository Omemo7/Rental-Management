using Microsoft.EntityFrameworkCore;
using Rental_Management.DataAccess.Entities;
using Shared.DTOs.Apartment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.DataAccess.Interfaces
{
    public interface IApartmentRepository: IRepository<Apartment>
    {

        Task<int> AddApartmentMaintenance(Maintenance entity);
        decimal GetApartmentTotalProfit(int apartmentId);
        
    }
}
