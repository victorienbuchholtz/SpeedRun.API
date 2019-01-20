using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpeedRun.ControllerGeneric;
using SpeedRun.Models.Models;
using SpeedRun.Services.Interfaces;

namespace SpeedRun.API.Controllers
{
    [Route("auth/")]
    public class AuthController : ControllerGeneric<User>
    {
        public AuthController(IUserService service) : base(service)
        {
        }

        [Route("signin")]
        public IActionResult SignIn(string returnUrl = "/auth/signinconfirmed")
        {
            return Challenge(new AuthenticationProperties { RedirectUri = returnUrl });
        }

        [Route("signinconfirmed")]
        public IActionResult SignInConfirmed()
        {
            User user = new User();
            if (User.Identity.IsAuthenticated)
            {
                user.FirstName = User.FindFirst(c => c.Type == ClaimTypes.Name)?.Value;
                user.AvatarUrl = User.FindFirst(c => c.Type == "urn:github:avatar")?.Value;
                user.Email = User.FindFirst(c => c.Type == "urn:github:email")?.Value;
                user.UserName = User.FindFirst(c => c.Type == "urn:github:login")?.Value;
                service.Add(user);
                return RedirectToRoute("http://localhost:4200/", user);
            }

            return BadRequest("Access denied");
        }

        [Route("signout")]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("http://localhost:4200/");
        }
    }
}