namespace Presentation.Contracts.Apartments
{
    public class ChangeApartmentSpecsRequest
    {
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public decimal AreaSqm { get; set; }
    }
}