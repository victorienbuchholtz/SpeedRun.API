using SpeedRun.Models.Models;
using SpeedRun.RepositoryGeneric.Interface;
using SpeedRun.ServiceGeneric;
using SpeedRun.Services.Interfaces;

namespace SpeedRun.Services.Services
{
    public class InventoryOperationService : ServiceGeneric<InventoryOperation>, IInventoryOperationService
    {
        public InventoryOperationService(IRepositoryGeneric<InventoryOperation> repo) : base(repo)
        {
        }
    }
}
