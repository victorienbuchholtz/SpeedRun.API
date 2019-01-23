using Microsoft.AspNetCore.Mvc;
using SpeedRun.API.Factories;
using SpeedRun.API.Models;
using SpeedRun.ControllerGeneric;
using SpeedRun.Models.Models;
using SpeedRun.Models.Models.Product;
using SpeedRun.Services.Interfaces;
using SpeedRun.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpeedRun.API.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("GetSimilarDbProductName")]
        public List<string> GetSimilarDbProductName(string name)
        {
            var products = service.GetAll(x => x.Name.Contains(name));
            var productNames = products.Select(x => x.Name).ToList();
            return productNames;
        }

        [HttpGet("GetSimilarDbProduct")]
        public List<Product> GetSimilarDbProduct(string name)
        {
            return service.GetAll(x => x.Name.Contains(name));
        }


        [HttpPost("ProductName")]
        public async Task<Product> Add([FromBody]IgdbGameMinified igdbGameMinified)
        {
            // TOOD : IMPLEMENTER
            // Vérifie si le jeu n'est pas déjà en base si c'est le cas soit on fait une erreur soit on fait un +1 dans l'inventaire
            // CALL IGDB API récupère les infos du jeu etc
            // on créait un product ( avec tout ce qu'il faut les screens etc... ) 
            // on ajoute en base
            // ( on peut appeler différent service si il le faut pour ajouter en base ce qu'on a besoin )
            // on retourne le product ( tu peux retourner juste le product pas besoin de retourner les collections avec si ça te fais chier )


            var dbProduct = service.Get(x => x.IgdbId == igdbGameMinified.id);
            if (dbProduct != null) return dbProduct;

            var product = await _igdbService.GetGameById(igdbGameMinified.id);

            if (product.Screenshots != null)
                foreach (Screenshot screenshot in product.Screenshots)
                    _screenshotService.Add(screenshot);

            product.DeliveryTime = 2;

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

    }
}
