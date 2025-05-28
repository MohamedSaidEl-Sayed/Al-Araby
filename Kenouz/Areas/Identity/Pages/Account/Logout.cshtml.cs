// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Kenouz.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Kenouz.Areas.Identity.Pages.Account
{
    [Authorize(Roles = "Admin")]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly Logged_in_Users_DbContext _loggedInUsers_DbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger,Logged_in_Users_DbContext logged_In_Users_DbContext, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _logger = logger;
            _loggedInUsers_DbContext = logged_In_Users_DbContext;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            if (User.IsInRole("Admin"))
            {
                var adminUserId = _userManager.GetUserId(User);
                Logged_in_Users admin = _loggedInUsers_DbContext.Logged_In_Users.SingleOrDefault(l => l.UserID == adminUserId);
                _loggedInUsers_DbContext.Logged_In_Users.Remove(admin);
                _loggedInUsers_DbContext.SaveChanges();
            }
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                // This needs to be a redirect so that the browser performs a new
                // request and the identity for the user gets updated.
                return RedirectToPage();
            }
        }
    }
}
