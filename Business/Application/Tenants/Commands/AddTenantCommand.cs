namespace Business.Application.Tenants.Commands
{
    public class AddTenantCommand
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string? Email { get; private set; }
        public string? PhoneNumber { get; private set; }

        public AddTenantCommand(string firstName, string lastName, string? email = null, string? phoneNumber = null)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}