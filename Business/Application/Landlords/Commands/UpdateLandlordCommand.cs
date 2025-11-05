using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Application.Landlords.Commands;
public sealed class UpdateLandlordCommand
{
    public Guid Id { get; set; }
    public string FirstName { get; private set; }
    public string LastName { get;private set; }

    public UpdateLandlordCommand(Guid id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

}
