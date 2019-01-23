using Microsoft.AspNetCore.Mvc;
using SpeedRun.ControllerGeneric;
using SpeedRun.Models.Models;
using SpeedRun.Services.Interfaces;

namespace SpeedRun.API.Controllers
{
    [Route("api/[controller]")]
    public class BasketController : ControllerGeneric<Basket>
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService service) : base(service)
        {
            _basketService = service;
        }
    }
}
