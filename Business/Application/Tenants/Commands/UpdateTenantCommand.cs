namespace Business.Application.Tenants.Commands
{
    public class UpdateTenantCommand
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string? Email { get; private set; }
        public string? PhoneNumber { get; private set; }

        public UpdateTenantCommand(Guid id, string firstName, string lastName, string? email = null, string? phoneNumber = null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

    }
}