using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.DTOs
{
    public class AddLandlordDTO
    {
        public int PersonId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

    }
}
