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
    public class UserServiceTester
    {
        private IUserService _userService;
        private readonly Mock<IRepositoryGeneric<User>> _userRepo;
        private string githubId = "totoAfrica";

        [TestInitialize]
        public void Initialize()
        {
            _userService = new UserService(_userRepo.Object);
        }

        [TestMethod]
        public void GetByIDGitHub_ThenAUserIsreturned()
        {
            ConfigureUserService();
            var user = _userService.GetByIDGitHub(githubId);
            Assert.IsNotNull(user);
        }

        public void ConfigureUserService()
        {
            _userRepo.Setup(x => x.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns(PrepareUser());
        }

        public User PrepareUser()
        {
            return new User()
            {
                FirstName = "Victorien",
                LastName = "Laloutre",
                ZipCode = "67000",
                Address = "Rue de la Loutre",
                City = "Strasbourg",
                IDGitHub = "UtilisateurGitHub",
                AvatarUrl = "http://urldelavatar.fr"
            };
        }
        
    }
}