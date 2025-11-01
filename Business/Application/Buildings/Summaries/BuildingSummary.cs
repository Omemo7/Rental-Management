using RentalManagement.Business.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Application.Buildings.Summaries
{
    public class BuildingSummary
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Street { get; set; }
        public string? Neighborhood { get; set; }
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string? PostalCode { get; set; }

        static public BuildingSummary FromBuilding(Building building)
        {
            return new BuildingSummary
            {
                Id = building.Id,
                Name = building.Name,
                Street = building.Address.Street,
                Neighborhood = building.Address.Neighborhood,
                City = building.Address.City,
                Country = building.Address.Country,
                PostalCode = building.Address.PostalCode
            };
        }

    }
}
