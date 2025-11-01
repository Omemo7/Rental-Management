using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityService _identity;

        public AccountController(IIdentityService identity) => _identity = identity;

        //[HttpPost("change-password")]
        //[Authorize]
        //public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordVm vm)
        //{
        //    var userId = User.GetUserId(); // your extension on ClaimsPrincipal -> Guid
        //    await _identity.ChangePassword(userId, vm.CurrentPassword, vm.NewPassword);
        //    return NoContent();
        //}
    }

    public record ChangePasswordVm(string CurrentPassword, string NewPassword);
}
