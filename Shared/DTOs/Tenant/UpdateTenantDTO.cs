using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.DTOs.Tenant
{
    public class UpdateTenantDTO
    {
        public int Id { get; set; }

        public string NationalNumber { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
