using Microsoft.AspNetCore.Mvc;
using SpeedRun.ControllerGeneric;
using SpeedRun.Models.Models;
using SpeedRun.Models.Models.Igdb;
using SpeedRun.Services.Interfaces;
using SpeedRun.Services.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpeedRun.API.Controllers
{
    [Route("api/[controller]/")]
    public class ProductController : ControllerGeneric<Product>
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IProductService _productService;
        private readonly IScreenshotService _screenshotService;

        private readonly IgdbService _igdbService;

        public ProductController(IProductService service, IHttpClientFactory clientFactory, IScreenshotService screenshotService, IgdbService igdbService) : base(service)
        {
            _clientFactory = clientFactory;
            _igdbService = igdbService;
            _productService = service;
            _screenshotService = screenshotService;
        }

        [HttpGet("GetSimilarProductName")]
        public async Task<List<IgdbGameMinified>> GetSimilarProductName(string name)
        {
            return await _igdbService.GetSimilarProductNameAsync(name);
        }

        [HttpGet("GetSimilarDbProduct")]
        public List<Product> GetSimilarDbProduct(string name)
        {
            return service.GetAll(x => x.Name.Contains(name));
        }

        [HttpPost("ProductName")]
        public async Task<Product> Add([FromBody]IgdbGameMinified igdbGameMinified)
        {
            var dbProduct = service.Get(x => x.IgdbId == igdbGameMinified.Id);
            if (dbProduct != null) return dbProduct;

            var product = await _igdbService.GetGameById(igdbGameMinified.Id);

            if (product.Screenshots != null)
                foreach (Screenshot screenshot in product.Screenshots)
                    _screenshotService.Add(screenshot);

            product.DeliveryTime = 2;
            product.Taxes = 20;

            _productService.Add(product);

            return product;
        }

        [HttpGet("ManageInventory")]
        public Product ManageInventory(Guid id, Boolean add)
        {
            var product = service.Get(x => x.Id == id);
            product = _productService.ManageInventory(product, add);
            service.Update(product);
            return product;
        }

        [HttpGet("Active")]
        public List<Product> Active()
        {
            return service.GetAll(x => x.Active);
        }

        [HttpGet("Featured")]
        public List<Product> Featured()
        {
            return service.GetAll(x => x.Active && x.Featured);
        }
    }
}
