using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity;



public sealed class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _users;
   

    public IdentityService(UserManager<ApplicationUser> users)
    {
        _users = users;
       
    }

    public Task<bool> IsEmailTaken(string email)
     => _users.Users.AnyAsync(u => u.Email == email);


    public async Task<Guid> CreateUser(string email, string password)
    {
        var user = new ApplicationUser
        {
            Id = Guid.NewGuid(),
            UserName = email,
            Email = email,
            
        };

        var res = await _users.CreateAsync(user, password);
        if (!res.Succeeded)
            throw new InvalidOperationException(string.Join("; ", res.Errors.Select(e => e.Description)));

        return user.Id;
    }

    public Task ChangePassword(Guid userId, string currentPassword, string newPassword)
    {
        throw new NotImplementedException();
    }
}

