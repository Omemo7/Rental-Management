namespace Business.Application.Apartments.Commands
{
    public class ChangeApartmentSpecsCommand
    {
        public Guid ApartmentId { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public decimal AreaSqm { get; set; }
    }
}