using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.Services.Roles;
using Moq;
using Xunit;

namespace FinalProjectTest
{
    public class RolesTest
    {
        [Fact]
        public async Task GetRolesTest()
        {
            var member1 = new Roles() { Role_id = 1, Role_name = "test role 1"};
            var member2 = new Roles() { Role_id = 2, Role_name = "test role 2"};
            var members = new List<Roles> { member1, member2 };

            var fakeRepositoryMock = new Mock<IRolesRepository>();

            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(members);

            var roleService = new RolesService(fakeRepositoryMock.Object);

            var resultRoles = await roleService.GetAll();

            Assert.Collection(resultRoles, role =>
            {
                Assert.Equal("test role 1", role.Role_name);
            },
            role =>
            {
                Assert.Equal("test role 2", role.Role_name);
            });
        }

        [Fact]
        public async Task GetRoleByIdTest()
        {
            var member1 = new Roles() { Role_id = 1, Role_name = "test role 1"};
            var member2 = new Roles() { Role_id = 1, Role_name = "test role 1 updated"};

            var fakeRepositoryMock = new Mock<IRolesRepository>();

            fakeRepositoryMock.Setup(x => x.GetByID(1)).ReturnsAsync(member1);

            var roleService = new RolesService(fakeRepositoryMock.Object);

            var resultRoles = await roleService.GetById(1);

            Assert.Equal("test role 1", resultRoles.Role_name);
        }

        [Fact]
        public async Task AddAndSaveTest()
        {
            var member1 = new Roles() { Role_id = 1, Role_name = "test role 1"};
            var member2 = new Roles() { Role_id = 2, Role_name = "test role 2"};
            var members = new List<Roles> { member1, member2 };

            var member3 = new Roles() { Role_id = 3, Role_name = "test role 3"};

            var fakeRepositoryMock = new Mock<IRolesRepository>();

            fakeRepositoryMock.Setup(x => x.Add(It.IsAny<Roles>())).Callback<Roles>(arg => members.Add(arg));

            var roleService = new RolesService(fakeRepositoryMock.Object);

            await roleService.AddAndSave(member3);


            Assert.Equal(3, members.Count);
        }

        [Fact]
        public async Task UpdateAndSaveTest()
        {
            var member1 = new Roles() { Role_id = 1, Role_name = "test role 1"};
            var member2 = new Roles() { Role_id = 2, Role_name = "test role 2"};
            var members = new List<Roles> { member1, member2 };

            var newMember2 = new Roles() { Role_id = 2, Role_name = "new test role 2"};

            var fakeRepositoryMock = new Mock<IRolesRepository>();

            fakeRepositoryMock.Setup(x => x.Update(It.IsAny<Roles>())).Callback<Roles>(arg => members[1] = arg);

            var roleService = new RolesService(fakeRepositoryMock.Object);

            await roleService.UpdateAndSave(newMember2);

            Assert.Equal("new test role 2", members[1].Role_name);
        }

        [Fact]
        public async Task DeleteAndSaveTest()
        {
            var member1 = new Roles() { Role_id = 1, Role_name = "test role 1"};
            var member2 = new Roles() { Role_id = 2, Role_name = "test role 2"};
            var members = new List<Roles> { member1, member2 };

            var fakeRepositoryMock = new Mock<IRolesRepository>();

            fakeRepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Callback<int>(arg => members.RemoveAt(1));

            var roleService = new RolesService(fakeRepositoryMock.Object);

            await roleService.DeleteAndSave(member2.Role_id);

            Assert.Single(members);
            Assert.Equal("test role 1", members[0].Role_name);
        }

        [Fact]
        public void ExistsTest()
        {
            var fakeRepositoryMock = new Mock<IRolesRepository>();

            fakeRepositoryMock.Setup(x => x.RoleExists(It.IsAny<int>())).Returns(true);

            var roleService = new RolesService(fakeRepositoryMock.Object);

            bool result = roleService.RoleExists(1);

            Assert.True(result);
        }
    }
}
