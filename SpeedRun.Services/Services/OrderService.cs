using SpeedRun.Models.Models;
using SpeedRun.RepositoryGeneric.Interface;
using SpeedRun.ServiceGeneric;
using SpeedRun.Services.Interfaces;

namespace SpeedRun.Services.Services
{
    public class OrderService : ServiceGeneric<Order>, IOrderService
    {
        public OrderService(IRepositoryGeneric<Order> repo) : base(repo)
        {
        }
    }
}
