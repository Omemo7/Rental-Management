using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Application.Landlords.Commands;
public sealed class UpdateLandlordCommand
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

}
