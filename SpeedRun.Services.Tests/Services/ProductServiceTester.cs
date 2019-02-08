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
    public class ProductServiceTester
    {
        private IProductService _productService;
        private Mock<IRepositoryGeneric<Product>> _productRepo;

        [TestInitialize]
        public void Initialize()
        {
            _productRepo = new Mock<IRepositoryGeneric<Product>>();
            _productService = new ProductService(_productRepo.Object);
        }

        [TestMethod]
        public void GetProduct_ThenAProductIsreturned()
        {
            ConfigureProductServiceGet();
            var product = _productService.Get(It.IsAny<Expression<Func<Product, bool>>>());
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public void AddProduct_ThenAProductIsreturned()
        {
            ConfigureProductServiceAdd();
            var product = _productService.Add(It.IsAny<Product>());
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public void UpdateProduct_ThenAProductIsreturned()
        {
            ConfigureProductServiceUpdate();
            var product = _productService.Update(It.IsAny<Product>());
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public void DeleteProduct_ThenVerifyIfItIsDeleted()
        {
            ConfigureProductServiceDelete();
            _productService.Delete(It.IsAny<Product>());
            _productRepo.Verify(x => x.Delete(It.IsAny<Product>()), Times.Exactly(1));
        }

        public void ConfigureProductServiceGet()
        {
            _productRepo.Setup(x => x.Get(It.IsAny<Expression<Func<Product, bool>>>())).Returns(PrepareProduct());
        }

        public void ConfigureProductServiceAdd()
        {
            _productRepo.Setup(x => x.Add(It.IsAny<Product>())).Returns(PrepareProduct());
        }

        public void ConfigureProductServiceUpdate()
        {
            _productRepo.Setup(x => x.Update(It.IsAny<Product>())).Returns(PrepareProduct());
        }

        public void ConfigureProductServiceDelete()
        {
            _productRepo.Setup(x => x.Delete(It.IsAny<Product>()));
        }

        public Product PrepareProduct()
        {
            return new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Summary = "TestSummary",
                StoryLine = "TestStoryLine",
                TotalRating = 50,
                RatingCount = 100,
                FirstReleaseDate = DateTime.Now,
                CoverUrl = "TestCover",
                PegiRating = 17,
                Price = 19.99,
                Taxes = 20,
                DeliveryTime = 2,
                Active = true,
                Featured = false
            };
        }

    }
}