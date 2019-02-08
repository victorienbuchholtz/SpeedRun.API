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
    public class ScreenshotServiceTester
    {
        private IScreenshotService _screenshotService;
        private Mock<IRepositoryGeneric<Screenshot>> _screenshotRepo;

        [TestInitialize]
        public void Initialize()
        {
            _screenshotRepo = new Mock<IRepositoryGeneric<Screenshot>>();
            _screenshotService = new ScreenshotService(_screenshotRepo.Object);
        }

        [TestMethod]
        public void GetScreenshot_ThenAScreenshotIsreturned()
        {
            ConfigureScreenshotServiceGet();
            var screenshot = _screenshotService.Get(It.IsAny<Expression<Func<Screenshot, bool>>>());
            Assert.IsNotNull(screenshot);
        }

        [TestMethod]
        public void AddScreenshot_ThenAScreenshotIsreturned()
        {
            ConfigureScreenshotServiceAdd();
            var screenshot = _screenshotService.Add(It.IsAny<Screenshot>());
            Assert.IsNotNull(screenshot);
        }

        [TestMethod]
        public void UpdateScreenshot_ThenAScreenshotIsreturned()
        {
            ConfigureScreenshotServiceUpdate();
            var screenshot = _screenshotService.Update(It.IsAny<Screenshot>());
            Assert.IsNotNull(screenshot);
        }

        [TestMethod]
        public void DeleteScreenshot_ThenVerifyIfItIsDeleted()
        {
            ConfigureScreenshotServiceDelete();
            _screenshotService.Delete(It.IsAny<Screenshot>());
            _screenshotRepo.Verify(x => x.Delete(It.IsAny<Screenshot>()), Times.Exactly(1));
        }

        public void ConfigureScreenshotServiceGet()
        {
            _screenshotRepo.Setup(x => x.Get(It.IsAny<Expression<Func<Screenshot, bool>>>())).Returns(PrepareScreenshot());
        }

        public void ConfigureScreenshotServiceAdd()
        {
            _screenshotRepo.Setup(x => x.Add(It.IsAny<Screenshot>())).Returns(PrepareScreenshot());
        }

        public void ConfigureScreenshotServiceUpdate()
        {
            _screenshotRepo.Setup(x => x.Update(It.IsAny<Screenshot>())).Returns(PrepareScreenshot());
        }

        public void ConfigureScreenshotServiceDelete()
        {
            _screenshotRepo.Setup(x => x.Delete(It.IsAny<Screenshot>()));
        }

        public Screenshot PrepareScreenshot()
        {
            return new Screenshot()
            {
                Id = Guid.NewGuid(),
                ScreenshotUrl = "testURL"
            };
        }

    }
}