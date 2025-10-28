using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.DTOs.Apartment
{
    public class ApartmentIdAndNameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
