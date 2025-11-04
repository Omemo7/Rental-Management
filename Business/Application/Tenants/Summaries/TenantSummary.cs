using RentalManagement.Business.Domain.Entities;

namespace Business.Application.Tenants.Summaries
{
    public class TenantSummary
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string? Email { get; private set; }
        public string? PhoneNumber { get; private set; }

        static public TenantSummary FromTenant(Tenant tenant)
        {
            return new TenantSummary
            {
                Id = tenant.Id,
                FirstName = tenant.FirstName,
                LastName = tenant.LastName,
                Email = tenant.Email,
                PhoneNumber = tenant.PhoneNumber
            };
        }
    }
}