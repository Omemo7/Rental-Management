using Rental_Management.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.DTOs
{
    public class AddApartmentDTO
    {
        public string StreetAddress { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string FloorNumber { get; set; }

        public string Type { get; set; }

        public string BuildingNumber { get; set; }

        public decimal SquaredMeters { get; set; }

        public int LandLordId { get; set; }



    }
}
