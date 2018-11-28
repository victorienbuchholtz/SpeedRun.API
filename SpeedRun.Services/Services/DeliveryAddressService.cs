using SpeedRun.Models.Models;
using SpeedRun.RepositoryGeneric.Interface;
using SpeedRun.ServiceGeneric;
using SpeedRun.Services.Interfaces;

namespace SpeedRun.Services.Services
{
    public class DeliveryAddressService : ServiceGeneric<DeliveryAddress>, IDeliveryAddressService 
    {
        public DeliveryAddressService(IRepositoryGeneric<DeliveryAddress> repo) : base(repo)
        {
        }
    }
}
