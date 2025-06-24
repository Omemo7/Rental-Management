using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.DataAccess.Entities
{
    public class Maintenance
    {
        public int Id { get; set; }
        public int? ApartmentId { get; set; } = null!;
        public virtual Apartment? Apartment { get; set; } = null!;


        public int? CarId { get; set; } = null!;
        public virtual Car? Car { get; set; } = null!;


        public int? CustomItemId { get; set; } = null!;
        public virtual CustomItem? CustomItem { get; set; } = null!;

        public decimal Cost { get; set; }

        public DateOnly MaintenanceDate { get; set; }

        public string Description { get; set; } = null!;

       
    }
}
