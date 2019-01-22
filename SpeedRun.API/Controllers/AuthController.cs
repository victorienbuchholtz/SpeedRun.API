using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeedRun.ControllerGeneric;
using SpeedRun.Models.Models;
using SpeedRun.Services.Interfaces;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SpeedRun.API.Controllers
{
    [Route("auth/")]
    public class AuthController : ControllerGeneric<User>
    {
        private readonly IUserService _userService;

        public AuthController(IUserService service) : base(service)
        {
            _userService = service;
        }

        [Route("signin")]
        public IActionResult SignIn(string returnUrl = "/auth/signinconfirmed")
        {
            return Challenge(new AuthenticationProperties { RedirectUri = returnUrl });
        }

        [Route("signinconfirmed")]
        public IActionResult SignInConfirmed()
        {
            if (User.Identity.IsAuthenticated)
            {
                User user = _userService.GetByIDGitHub(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);

                user.IDGitHub = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                user.FirstName = User.FindFirst(c => c.Type == ClaimTypes.Name)?.Value;
                user.AvatarUrl = User.FindFirst(c => c.Type == "urn:github:avatar")?.Value;
                user.Email = User.FindFirst(c => c.Type == "urn:github:email")?.Value;
                user.UserName = User.FindFirst(c => c.Type == "urn:github:login")?.Value;

                if (user.Id == Guid.Empty)
                    service.Add(user);
                else
                    service.Update(user);

                return Redirect("http://localhost:4200/");
            }

            return BadRequest("Access denied");
        }

        [Route("authenticate")]
        public User Authenticate()
        {
            if (User.Identity.IsAuthenticated)
            {
                User user = _userService.GetByIDGitHub(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
                return user;
            }
            return null;
        }

        [Route("signout")]
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("http://localhost:4200/");
        }
    }
}