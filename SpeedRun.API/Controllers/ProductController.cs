using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SpeedRun.API.Factories;
using SpeedRun.ControllerGeneric;
using SpeedRun.Models.Models.Product;
using SpeedRun.Services.Interfaces;

namespace SpeedRun.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerGeneric<Product>
    {
        public ProductController(IProductService service) : base(service)
        {
        }

        [HttpGet("GetSimilarGameName")]
        public List<string> GetSimilarGameName(string name)
        {
            // TODO : IMPLEMENTER
            // CALL IGDB API récupère les noms des jeux similaire à name
            // les retourner sous forme List<string>
            // ou alors on retourne une list d'un nouvelle objet qui a pour property name et id 
            // id est remplie si le nom du jeu est déjà présent en base ?

            return ProductFactory.GetProductNames(name);
        }

        [HttpPost]
        public Product Add(string name)
        {
            // TOOD : IMPLEMENTER
            // Vérifie si le jeu n'est pas déjà en base si c'est le cas soit on fait une erreur soit on fait un +1 dans l'inventaire
            // CALL IGDB API récupère les infos du jeu etc
            // on créait un product ( avec tout ce qu'il faut les screens etc... ) 
            // on ajoute en base
            // ( on peut appeler différent service si il le faut pour ajouter en base ce qu'on a besoin )
            // on retourne le product ( tu peux retourner juste le product pas besoin de retourner les collections avec si ça te fais chier )
            var dbProduct = service.Get(x => x.Name == name);
            if (dbProduct != null) return dbProduct;

            var product = ProductFactory.GetProduct(name);
            service.Add(product);
            return product;
        }

    }
}
