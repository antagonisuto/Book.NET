using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.Services.Roles;
using FinalProject.Services.Userss;
using Moq;
using Xunit;

namespace FinalProjectTest
{
    public class UserssTest
    {
        [Fact]
        public async Task GetAllTest()
        {
            var user1 = new Userss() { User_id = 1, Username = "test user 1", Password = "test password 1", FullName = "test FullName 1", Role_id = 1 };
            var user2 = new Userss() { User_id = 2, Username = "test user 2", Password = "test password 2", FullName = "test FullName 1", Role_id = 2 };
            var users = new List<Userss> { user1, user2 };

            var fakeUserssRepositoryMock = new Mock<IUserssRepository>();
            var fakeRolesRepositoryMock = new Mock<IRolesRepository>();

            fakeUserssRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(users);

            var equipmentService = new UserssService(fakeUserssRepositoryMock.Object, fakeRolesRepositoryMock.Object);

            var resultUserss = await equipmentService.GetAllUsers();

            Assert.Collection(resultUserss, equipment =>
            {
                Assert.Equal("test user 1", equipment.Username);
            },
            equipment =>
            {
                Assert.Equal("test user 2", equipment.Username);
            });
        }

        [Fact]
        public async Task GetByIdTest()
        {
            var user1 = new Userss() { User_id = 1, Username = "test user 1", Password = "test password 1", FullName = "test FullName 1", Role_id = 1 };
            var user2 = new Userss() { User_id = 2, Username = "test user 2", Password = "test password 2", FullName = "test FullName 1", Role_id = 2 };

            var fakeUserssRepositoryMock = new Mock<IUserssRepository>();
            var fakeRolesRepositoryMock = new Mock<IRolesRepository>();

            fakeUserssRepositoryMock.Setup(x => x.GetByID(1)).ReturnsAsync(user1);

            var equipmentService = new UserssService(fakeUserssRepositoryMock.Object, fakeRolesRepositoryMock.Object);

            var result = await equipmentService.GetById(1);

            Assert.Equal("test user 1", result.Username);
        }

        [Fact]
        public async Task AddAndSaveTest()
        {
            var user1 = new Userss() { User_id = 1, Username = "test user 1", Password = "test password 1", FullName = "test FullName 1", Role_id = 1 };
            var user2 = new Userss() { User_id = 2, Username = "test user 2", Password = "test password 2", FullName = "test FullName 1", Role_id = 2 };
            var users = new List<Userss> { user1, user2 };

            var user3 = new Userss() { User_id = 2, Username = "test user 2", Password = "test password 2", FullName = "test FullName 1", Role_id = 2 };

            var fakeUserssRepositoryMock = new Mock<IUserssRepository>();
            var fakeRolesRepositoryMock = new Mock<IRolesRepository>();

            fakeUserssRepositoryMock.Setup(x => x.Add(It.IsAny<Userss>())).Callback<Userss>(arg => users.Add(arg));

            var equipmentService = new UserssService(fakeUserssRepositoryMock.Object, fakeRolesRepositoryMock.Object);

            await equipmentService.AddAndSave(user3);


            Assert.Equal(3, users.Count);
        }

        [Fact]
        public async Task UpdateAndSaveTest()
        {
            var user1 = new Userss() { User_id = 1, Username = "test user 1", Password = "test password 1", FullName = "test FullName 1", Role_id = 1 };
            var user2 = new Userss() { User_id = 2, Username = "test user 2", Password = "test password 2", FullName = "test FullName 1", Role_id = 2 };
            var users = new List<Userss> { user1, user2 };

            var newuser2 = new Userss() { User_id = 2, Username = "test user 2", Password = "test password 2", FullName = "test FullName 1", Role_id = 2 };

            var fakeUserssRepositoryMock = new Mock<IUserssRepository>();
            var fakeRolesRepositoryMock = new Mock<IRolesRepository>();

            fakeUserssRepositoryMock.Setup(x => x.Update(It.IsAny<Userss>())).Callback<Userss>(arg => users[1] = arg);

            var equipmentService = new UserssService(fakeUserssRepositoryMock.Object, fakeRolesRepositoryMock.Object);

            await equipmentService.UpdateAndSave(newuser2);

            Assert.Equal("test user 2", users[1].Username);
        }

        [Fact]
        public async Task DeleteAndSaveTest()
        {
            var user1 = new Userss() { User_id = 1, Username = "test user 1", Password = "test password 1", FullName = "test FullName 1", Role_id = 1 };
            var user2 = new Userss() { User_id = 2, Username = "test user 2", Password = "test password 2", FullName = "test FullName 1", Role_id = 2 };
            var users = new List<Userss> { user1, user2 };

            var fakeUserssRepositoryMock = new Mock<IUserssRepository>();
            var fakeRolesRepositoryMock = new Mock<IRolesRepository>();

            fakeUserssRepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Callback<int>(arg => users.RemoveAt(1));

            var equipmentService = new UserssService(fakeUserssRepositoryMock.Object, fakeRolesRepositoryMock.Object);

            await equipmentService.DeleteAndSave(user2.User_id);

            Assert.Single(users);
            Assert.Equal("test user 1", users[0].Username);
        }

        [Fact]
        public void ExistsTest()
        {
            var fakeUserssRepositoryMock = new Mock<IUserssRepository>();
            var fakeRolesRepositoryMock = new Mock<IRolesRepository>();

            fakeUserssRepositoryMock.Setup(x => x.UserExists(It.IsAny<int>())).Returns(true);

            var equipmentService = new UserssService(fakeUserssRepositoryMock.Object, fakeRolesRepositoryMock.Object);

            bool result = equipmentService.UserExists(1);

            Assert.True(result);
        }
    }
}
