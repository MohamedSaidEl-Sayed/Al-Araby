using Kenouz.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Kenouz.Controllers.Helper
{
    public class CheckCode
    {
        private readonly Logged_in_Users_DbContext _logged_In_Users;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public CheckCode(Logged_in_Users_DbContext logged_In_Users, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _logged_In_Users = logged_In_Users;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> Check(string Code)
        {
            var u = await _userManager.FindByNameAsync(Code);
            if(u is null) // u is null=>the code is deleted
            {
                await _signInManager.SignOutAsync();
                return false;
            }
            var d = _logged_In_Users.DeactivatedUsers.AsNoTracking().FirstOrDefault(d => d.UserId == Code);
            var l = _logged_In_Users.Logged_In_Users.AsNoTracking().FirstOrDefault(d => d.UserID == u.Id);
            if (d is not null || l is null) // d is not null=>the code is deactivated
            {
                await _signInManager.SignOutAsync();
                return false;
            }
            return true;
        }
    }
}
