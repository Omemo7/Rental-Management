using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.DTOs.Apartment
{
    public class AddApartmentMaintenanceDTO
    {
        public int ApartmentId { get; set; }


        public decimal Cost { get; set; }

        public DateOnly MaintenanceDate { get; set; }

        public string Description { get; set; } = null!;

    }
}
