using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SpeedRun.Models.Models;
using SpeedRun.RepositoryGeneric.Interface;
using SpeedRun.Services.Interfaces;
using SpeedRun.Services.Services;
using System;
using System.Linq.Expressions;

namespace SpeedRun.Services.Tests.Services
{
    [TestClass]
    public class InventoryOperationServiceTester
    {
        private IInventoryOperationService _inventoryOperationService;
        private Mock<IRepositoryGeneric<InventoryOperation>> _inventoryOperationRepo;

        [TestInitialize]
        public void Initialize()
        {
            _inventoryOperationRepo = new Mock<IRepositoryGeneric<InventoryOperation>>();
            _inventoryOperationService = new InventoryOperationService(_inventoryOperationRepo.Object);
        }

        [TestMethod]
        public void GetInventoryOperation_ThenAInventoryOperationIsreturned()
        {
            ConfigureInventoryOperationServiceGet();
            var inventoryOperation = _inventoryOperationService.Get(It.IsAny<Expression<Func<InventoryOperation, bool>>>());
            Assert.IsNotNull(inventoryOperation);
        }

        [TestMethod]
        public void AddInventoryOperation_ThenAInventoryOperationIsreturned()
        {
            ConfigureInventoryOperationServiceAdd();
            var inventoryOperation = _inventoryOperationService.Add(It.IsAny<InventoryOperation>());
            Assert.IsNotNull(inventoryOperation);
        }

        [TestMethod]
        public void UpdateInventoryOperation_ThenAInventoryOperationIsreturned()
        {
            ConfigureInventoryOperationServiceUpdate();
            var inventoryOperation = _inventoryOperationService.Update(It.IsAny<InventoryOperation>());
            Assert.IsNotNull(inventoryOperation);
        }

        [TestMethod]
        public void DeleteInventoryOperation_ThenVerifyIfItIsDeleted()
        {
            ConfigureInventoryOperationServiceDelete();
            _inventoryOperationService.Delete(It.IsAny<InventoryOperation>());
            _inventoryOperationRepo.Verify(x => x.Delete(It.IsAny<InventoryOperation>()), Times.Exactly(1));
        }

        public void ConfigureInventoryOperationServiceGet()
        {
            _inventoryOperationRepo.Setup(x => x.Get(It.IsAny<Expression<Func<InventoryOperation, bool>>>())).Returns(PrepareInventoryOperation());
        }

        public void ConfigureInventoryOperationServiceAdd()
        {
            _inventoryOperationRepo.Setup(x => x.Add(It.IsAny<InventoryOperation>())).Returns(PrepareInventoryOperation());
        }

        public void ConfigureInventoryOperationServiceUpdate()
        {
            _inventoryOperationRepo.Setup(x => x.Update(It.IsAny<InventoryOperation>())).Returns(PrepareInventoryOperation());
        }

        public void ConfigureInventoryOperationServiceDelete()
        {
            _inventoryOperationRepo.Setup(x => x.Delete(It.IsAny<InventoryOperation>()));
        }

        public InventoryOperation PrepareInventoryOperation()
        {
            return new InventoryOperation()
            {
                Id = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                OperationType = 0
            };
        }
    }
}