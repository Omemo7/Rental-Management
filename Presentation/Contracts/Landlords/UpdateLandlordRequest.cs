using Business.Application.Landlords.Commands;

namespace Presentation.Contracts.Landlords
{
    public class UpdateLandlordRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UpdateLandlordCommand ToCommand(Guid Id)
            => new UpdateLandlordCommand(Id,FirstName, LastName);
    }
}
