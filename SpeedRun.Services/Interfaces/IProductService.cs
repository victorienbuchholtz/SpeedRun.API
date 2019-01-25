using SpeedRun.Models.Models;
using SpeedRun.ServiceGeneric.Interface;

namespace SpeedRun.Services.Interfaces
{
    public interface IProductService : IServiceGeneric<Product>
    {
        Product ManageInventory(Product product, bool add);
    }
}