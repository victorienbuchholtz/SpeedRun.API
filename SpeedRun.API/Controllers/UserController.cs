using Microsoft.AspNetCore.Mvc;
using SpeedRun.ControllerGeneric;
using SpeedRun.Models.Models;
using SpeedRun.Services.Interfaces;

namespace SpeedRun.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerGeneric<User>
    {
        public UserController(IUserService service) : base(service)
        {
        }
    }
}
