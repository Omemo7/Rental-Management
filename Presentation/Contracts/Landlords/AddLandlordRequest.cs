﻿namespace Presentation.Contracts.Landlords;
public sealed class AddLandlordRequest
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

}
