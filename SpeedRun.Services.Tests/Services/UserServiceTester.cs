﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private Mock<IRepositoryGeneric<User>> _userRepo;
        private readonly string githubId = "totoAfrica";
        private readonly string wrongGitHubId = "africaToto";

        [TestInitialize]
        public void Initialize()
        {
            _userRepo = new Mock<IRepositoryGeneric<User>>();
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
        public void GetByIDGitHub_WithWrongIDGithub_ThenAUserIsreturned()
        {
            ConfigureUserServiceGetByIdGitHub();
            var user = _userService.GetByIDGitHub(wrongGitHubId);
            Assert.IsNull(user.Id != Guid.Empty ? user : null);
        }

        [TestMethod]
        public void GetUser_ThenAUserIsreturned()
        {
            ConfigureUserServiceGet();
            var user = _userService.Get(It.IsAny<Expression<Func<User, bool>>>());
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void AddUser_ThenAUserIsreturned()
        {
            ConfigureUserServiceAdd();
            var user = _userService.Add(It.IsAny<User>());
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void UpdateUser_ThenAUserIsreturned()
        {
            ConfigureUserServiceUpdate();
            var user = _userService.Update(It.IsAny<User>());
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void DeleteUser_ThenVerifyIfItIsDeleted()
        {
            ConfigureUserServiceDelete();
            _userService.Delete(It.IsAny<User>());
            _userRepo.Verify(x => x.Delete(It.IsAny<User>()), Times.Exactly(1));
        }

        public void ConfigureUserServiceGet()
        {
            _userRepo.Setup(x => x.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns(PrepareUser());
        }

        public void ConfigureUserServiceGetByIdGitHub()
        {
            _userRepo.Setup(x => x.Get(It.IsAny<Expression<Func<User, bool>>>())).Returns(new User());
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
                Id = Guid.NewGuid(),
                FirstName = "Victorien",
                LastName = "Laloutre",
                ZipCode = "67000",
                Address = "Rue de la Loutre",
                City = "Strasbourg",
                IDGitHub = "totoAfrica",
                AvatarUrl = "http://urldelavatar.fr"
            };
        }
        
    }
}