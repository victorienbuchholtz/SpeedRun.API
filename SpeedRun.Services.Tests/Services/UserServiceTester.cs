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
            ConfigureUserServiceGet();
            var user = _userService.GetByIDGitHub(githubId);
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void Get_ThenAUserIsreturned()
        {
            ConfigureUserServiceGet();
            User u = new User();
            var user = _userService.Get(It.IsAny<Expression<Func<User, bool>>>());
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void Add_ThenAUserIsreturned()
        {
            ConfigureUserServiceGet();
            var user = _userService.GetByIDGitHub(githubId);
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void Update_ThenAUserIsreturned()
        {
            ConfigureUserServiceGet();
            var user = _userService.GetByIDGitHub(githubId);
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void Delete_ThenAUserIsreturned()
        {
            ConfigureUserServiceGet();
            var user = _userService.GetByIDGitHub(githubId);
            Assert.IsNotNull(user);
        }

        public void ConfigureUserServiceGet()
        {
            _userRepo.Setup(x => x.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns(PrepareUser());
        }

        public void ConfigureUserServiceAdd()
        {
            _userRepo.Setup(x => x.Add(It.IsAny<User>())).Returns(PrepareUser());
        }

        public void ConfigureUserServiceUpdate()
        {
            _userRepo.Setup(x => x.Update(It.IsAny<User>())).Returns(PrepareUser());
        }

        public void ConfigureUserServiceDelete()
        {
            _userRepo.Setup(x => x.Delete(It.IsAny<User>()));
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