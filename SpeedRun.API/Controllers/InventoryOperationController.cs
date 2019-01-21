using Microsoft.AspNetCore.Mvc;
using SpeedRun.ControllerGeneric;
using SpeedRun.Models.Models;
using SpeedRun.Services.Interfaces;

namespace SpeedRun.API.Controllers
{
    [Route("api/[controller]")]
    public class InventoryOperationController : ControllerGeneric<InventoryOperation>
    {
        private readonly IInventoryOperationService _inventoryOperationService;

        public InventoryOperationController(IInventoryOperationService service) : base(service)
        {
            _inventoryOperationService = service;
        }

    }
}
