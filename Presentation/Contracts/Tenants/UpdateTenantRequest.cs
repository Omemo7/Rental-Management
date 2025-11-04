using Business.Application.Tenants.Commands;

namespace Presentation.Contracts.Tenants
{
    public class UpdateTenantRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public UpdateTenantCommand ToCommand(Guid tenantId)
        {
            return new UpdateTenantCommand(tenantId, FirstName, LastName, Email, PhoneNumber);
        }
    }
}
