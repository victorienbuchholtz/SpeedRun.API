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

        public Product ManageInventory(Product product, bool add)
        {
            /*
            if (add)
            {
                product.Inventory++;
            }
            else
            {
                if (product.Inventory > 0)
                {
                    product.Inventory--;
                }
            }
            */
            return product;
        }
    }
}
