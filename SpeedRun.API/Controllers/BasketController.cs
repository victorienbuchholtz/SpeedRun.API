using Microsoft.AspNetCore.Mvc;
using SpeedRun.API.Models;
using SpeedRun.ControllerGeneric;
using SpeedRun.Models.Models;
using SpeedRun.Services.Interfaces;

namespace SpeedRun.API.Controllers
{
    [Route("api/[controller]")]
    public class BasketController : ControllerGeneric<Basket>
    {
        private readonly IBasketService _basketService;
        private readonly IUserService _userService;
        private readonly IProductService _productService;



        public BasketController(IBasketService service, IUserService userService, IProductService productService) : base(service)
        {
            _basketService = service;
            _userService = userService;
            _productService = productService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] BasketAddModel basketAddModel)
        {
            if (basketAddModel == null) return BadRequest("Invalid form");
            // soit par l'Id soit par autre chose
            //var user = _userService.Get(x => x.Id == Un Genre didée);
            //var product = _productService.Get(x => x.Id == basketAddModel.ProductId);
            //var basket = new Basket(user, product);
            //_basketService.Add(basket);
            return null;
        }

        [HttpGet("user")]
        public Basket GetByUser()
        {
            //var user = _userService.Get(x => x.Id == un genre didée);
            //var basket = _basketService.Get(x => x.UserId == user.Id && x.Archived == false);
            //return basket;
            return null;
        }

    }
}
