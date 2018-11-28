using SpeedRun.Models.Models;
using SpeedRun.RepositoryGeneric.Interface;
using SpeedRun.ServiceGeneric;
using SpeedRun.Services.Interfaces;

namespace SpeedRun.Services.Services
{
    public class ProductService : ServiceGeneric<Product>, IProductService
    {
        public ProductService(IRepositoryGeneric<Product> repo) : base(repo)
        {
        }
    }
}
