using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace SpeedRun.API.Controllers
{
    [Route("auth/")]
    public class AuthController : Controller
    {
        [Route("signin")]
        public IActionResult SignIn() => View();

        [Route("signin/{provider}")]
        public IActionResult SignIn(string provider)
        {
            AuthenticationProperties ap = new AuthenticationProperties { RedirectUri = "/" };
            var challenge = Challenge(ap, provider);
            return challenge;
        }

        [Route("signout")]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("http://localhost:4200/");
        }
    }
}