using Business.Application.Tenants.Commands;

namespace Presentation.Contracts.Tenants
{
    public class AddTenantRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public AddTenantCommand ToCommand()
        {
            return new AddTenantCommand(
                firstName: FirstName,
                lastName: LastName,
                email: Email,
                phoneNumber: PhoneNumber
            );
        }
    }
}