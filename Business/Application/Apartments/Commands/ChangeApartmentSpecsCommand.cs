namespace Business.Application.Apartments.Commands
{
    public class ChangeApartmentSpecsCommand
    {
        public ChangeApartmentSpecsCommand(Guid id, int bedrooms, int bathrooms, decimal areaSqm)
        {
            Id = id;
            Bedrooms = bedrooms;
            Bathrooms = bathrooms;
            AreaSqm = areaSqm;
        }

        public Guid Id { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public decimal AreaSqm { get; set; }
    }
}