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
    public class OrderServiceTester
    {
        private IOrderService _orderService;
        private Mock<IRepositoryGeneric<Order>> _orderRepo;

        [TestInitialize]
        public void Initialize()
        {
            _orderRepo = new Mock<IRepositoryGeneric<Order>>();
            _orderService = new OrderService(_orderRepo.Object);
        }

        [TestMethod]
        public void GetOrder_ThenAOrderIsreturned()
        {
            ConfigureOrderServiceGet();
            var order = _orderService.Get(It.IsAny<Expression<Func<Order, bool>>>());
            Assert.IsNotNull(order);
        }

        [TestMethod]
        public void AddOrder_ThenAOrderIsreturned()
        {
            ConfigureOrderServiceAdd();
            var order = _orderService.Add(It.IsAny<Order>());
            Assert.IsNotNull(order);
        }

        [TestMethod]
        public void UpdateOrder_ThenAOrderIsreturned()
        {
            ConfigureOrderServiceUpdate();
            var order = _orderService.Update(It.IsAny<Order>());
            Assert.IsNotNull(order);
        }

        [TestMethod]
        public void DeleteOrder_ThenVerifyIfItIsDeleted()
        {
            ConfigureOrderServiceDelete();
            _orderService.Delete(It.IsAny<Order>());
            _orderRepo.Verify(x => x.Delete(It.IsAny<Order>()), Times.Exactly(1));
        }

        public void ConfigureOrderServiceGet()
        {
            _orderRepo.Setup(x => x.Get(It.IsAny<Expression<Func<Order, bool>>>())).Returns(PrepareOrder());
        }

        public void ConfigureOrderServiceAdd()
        {
            _orderRepo.Setup(x => x.Add(It.IsAny<Order>())).Returns(PrepareOrder());
        }

        public void ConfigureOrderServiceUpdate()
        {
            _orderRepo.Setup(x => x.Update(It.IsAny<Order>())).Returns(PrepareOrder());
        }

        public void ConfigureOrderServiceDelete()
        {
            _orderRepo.Setup(x => x.Delete(It.IsAny<Order>()));
        }

        public Order PrepareOrder()
        {
            return new Order()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                User = new User()
            };
        }
    }
}