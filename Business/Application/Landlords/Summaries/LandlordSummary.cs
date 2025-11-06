using RentalManagement.Business.Domain.Entities;

namespace Business.Application.Landlords.Summaries
{
    public class LandlordSummary
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public static LandlordSummary FromLandlord(Landlord landlord)
        {
            return new LandlordSummary
            {
                Id = landlord.Id,
                FirstName = landlord.FirstName,
                LastName = landlord.LastName
            };
        }
    }
}