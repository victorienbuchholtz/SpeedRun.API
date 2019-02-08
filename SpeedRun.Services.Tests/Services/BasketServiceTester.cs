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
    public class BasketServiceTester
    {
        private IBasketService _basketService;
        private Mock<IRepositoryGeneric<Basket>> _basketRepo;

        [TestInitialize]
        public void Initialize()
        {
            _basketRepo = new Mock<IRepositoryGeneric<Basket>>();
            _basketService = new BasketService(_basketRepo.Object);
        }

        [TestMethod]
        public void GetBasket_ThenABasketIsreturned()
        {
            ConfigureBasketServiceGet();
            var basket = _basketService.Get(It.IsAny<Expression<Func<Basket, bool>>>());
            Assert.IsNotNull(basket);
        }

        [TestMethod]
        public void AddBasket_ThenABasketIsreturned()
        {
            ConfigureBasketServiceAdd();
            var basket = _basketService.Add(It.IsAny<Basket>());
            Assert.IsNotNull(basket);
        }

        [TestMethod]
        public void UpdateBasket_ThenABasketIsreturned()
        {
            ConfigureBasketServiceUpdate();
            var basket = _basketService.Update(It.IsAny<Basket>());
            Assert.IsNotNull(basket);
        }

        [TestMethod]
        public void DeleteBasket_ThenVerifyIfItIsDeleted()
        {
            ConfigureBasketServiceDelete();
            _basketService.Delete(It.IsAny<Basket>());
            _basketRepo.Verify(x => x.Delete(It.IsAny<Basket>()), Times.Exactly(1));
        }

        public void ConfigureBasketServiceGet()
        {
            _basketRepo.Setup(x => x.Get(It.IsAny<Expression<Func<Basket, bool>>>())).Returns(PrepareBasket());
        }

        public void ConfigureBasketServiceAdd()
        {
            _basketRepo.Setup(x => x.Add(It.IsAny<Basket>())).Returns(PrepareBasket());
        }

        public void ConfigureBasketServiceUpdate()
        {
            _basketRepo.Setup(x => x.Update(It.IsAny<Basket>())).Returns(PrepareBasket());
        }

        public void ConfigureBasketServiceDelete()
        {
            _basketRepo.Setup(x => x.Delete(It.IsAny<Basket>()));
        }

        public Basket PrepareBasket()
        {
            return new Basket()
            {
                Id = Guid.NewGuid(),
                Product = new Product(),
                User = new User()
            };
        }

    }
}