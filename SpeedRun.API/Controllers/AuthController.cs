using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeedRun.ControllerGeneric;
using SpeedRun.Models.Models;
using SpeedRun.Services.Interfaces;
using System;
using System.Net.Http;
using System.Security.Claims;

namespace SpeedRun.API.Controllers
{
    [Route("auth/")]
    public class AuthController : ControllerGeneric<User>
    {
        private readonly IUserService _userService;
        private readonly IHttpClientFactory _clientFactory;

        public AuthController(IUserService service, IHttpClientFactory clientFactory) : base(service)
        {
            _userService = service;
            _clientFactory = clientFactory;
        }

        [Route("signin")]
        public IActionResult SignIn(string returnUrl = "auth/signinconfirmed")
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
            User user = _userService.GetByIDGitHub(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return user;
        }

        [Route("signout")]
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("http://localhost:4200/");
        }
    }
}