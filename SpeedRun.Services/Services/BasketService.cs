using SpeedRun.Models.Models;
using SpeedRun.RepositoryGeneric.Interface;
using SpeedRun.ServiceGeneric;
using SpeedRun.Services.Interfaces;

namespace SpeedRun.Services.Services
{
    public class BasketService : ServiceGeneric<Basket>, IBasketService
    {
        public BasketService(IRepositoryGeneric<Basket> repo) : base(repo)
        {
        }
    }
}
