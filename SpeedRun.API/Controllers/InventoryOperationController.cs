using Microsoft.AspNetCore.Mvc;
using SpeedRun.ControllerGeneric;
using SpeedRun.Models.Enums;
using SpeedRun.Models.Models;
using SpeedRun.Services.Interfaces;

namespace SpeedRun.API.Controllers
{
    [Route("api/[controller]")]
    public class InventoryOperationController : ControllerGeneric<InventoryOperation>
    {
        private readonly IInventoryOperationService _inventoryOperationService;
        private readonly IProductService _productService;

        public InventoryOperationController(IInventoryOperationService service, IProductService productService) : base(service)
        {
            _inventoryOperationService = service;
            _productService = productService;
        }

        [HttpPost]
        public override IActionResult Add([FromBody] InventoryOperation inventoryOperation)
        {
            var product = _productService.Get(x => x.Id == inventoryOperation.ProductId);
            if (inventoryOperation.OperationType == OperationType.Withdraw && product.Inventory == 0)
                return BadRequest("There is no product to withdraw");
            service.Add(inventoryOperation);
            return Ok(inventoryOperation);
        }

    }
}
