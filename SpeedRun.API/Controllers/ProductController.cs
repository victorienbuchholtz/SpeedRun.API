using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SpeedRun.API.Factories;
using SpeedRun.API.Models;
using SpeedRun.ControllerGeneric;
using SpeedRun.Models.Models.Product;
using SpeedRun.Services.Interfaces;
using SpeedRun.Services.Services;
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
        private readonly IgdbService _igdbService;
        private readonly IProductService _productService;

        public ProductController(IProductService service, IHttpClientFactory clientFactory, IgdbService igdbService) : base(service)
        {
            _clientFactory = clientFactory;
            _igdbService = igdbService;
            _productService = service;
        }

        [HttpGet("GetSimilarProductName")]
        public async Task<List<string>> GetSimilarProductName(string name)
        {
            // TODO : IMPLEMENTER
            // CALL IGDB API récupère les noms des jeux similaire à name
            // les retourner sous forme List<string>
            // ou alors on retourne une list d'un nouvelle objet qui a pour property name et id 
            // id est remplie si le nom du jeu est déjà présent en base ?
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
        public Product Add([FromBody]ProductAddModel productAddModel)
        {
            // TOOD : IMPLEMENTER
            // Vérifie si le jeu n'est pas déjà en base si c'est le cas soit on fait une erreur soit on fait un +1 dans l'inventaire
            // CALL IGDB API récupère les infos du jeu etc
            // on créait un product ( avec tout ce qu'il faut les screens etc... ) 
            // on ajoute en base
            // ( on peut appeler différent service si il le faut pour ajouter en base ce qu'on a besoin )
            // on retourne le product ( tu peux retourner juste le product pas besoin de retourner les collections avec si ça te fais chier )
            var dbProduct = service.Get(x => x.Name == productAddModel.name);
            if (dbProduct != null) return dbProduct;

            var product = ProductFactory.GetProduct(productAddModel.name);
            service.Add(product);
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
