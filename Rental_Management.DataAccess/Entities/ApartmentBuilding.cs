using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.DataAccess.Entities
{
    public class ApartmentBuilding
    {
        public int Id { get; set; }
        public string BuildingNumber { get; set; } = null!;
        public string StreetAddress { get; set; } = null!;
        public string Neighborhood { get; set; } = null!;
        
        public string City { get; set; } = null!;
        public int landLordId { get; set; }
        public virtual Landlord LandLord { get; set; } = null!;

        public virtual ICollection<Apartment> Apartments { get; set; } = new List<Apartment>();
    }
}
