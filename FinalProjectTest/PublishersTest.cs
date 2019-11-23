using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.Services.Publishers;
using Moq;
using Xunit;

namespace FinalProjectTest
{
    public class PublishersTest
    {
        [Fact]
        public async Task GetPublisherTest()
        {
            var pub1 = new Publishers() { Pub_id = 1, Pub_name = "test pub 1"};
            var pub2 = new Publishers() { Pub_id = 2, Pub_name = "test pub 2"};
            var pubs = new List<Publishers> { pub1, pub2 };

            var fakeRepositoryMock = new Mock<IPublishersRepository>();

            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(pubs);

            var pubService = new PublishersService(fakeRepositoryMock.Object);

            var resultMembers = await pubService.GetAll();

            Assert.Collection(resultMembers, pub =>
            {
                Assert.Equal("test pub 1", pub.Pub_name);
            },
            pub =>
            {
                Assert.Equal("test pub 2", pub.Pub_name);
            });
        }

        [Fact]
        public async Task GetMemberByIdTest()
        {
            var pub1 = new Publishers() { Pub_id = 1, Pub_name = "test pub 1" };
            var pub2 = new Publishers() { Pub_id = 2, Pub_name = "test pub 2" };

            var fakeRepositoryMock = new Mock<IPublishersRepository>();

            fakeRepositoryMock.Setup(x => x.GetByID(1)).ReturnsAsync(pub1);

            var pubService = new PublishersService(fakeRepositoryMock.Object);

            var resultMember = await pubService.GetById(1);

            Assert.Equal("test pub 1", resultMember.Pub_name);
        }

        [Fact]
        public async Task AddAndSaveTest()
        {
            var pub1 = new Publishers() { Pub_id = 1, Pub_name = "test pub 1" };
            var pub2 = new Publishers() { Pub_id = 2, Pub_name = "test pub 2" };
            var pubs = new List<Publishers> { pub1, pub2 };

            var pub3 = new Publishers() { Pub_id = 2, Pub_name = "test pub 2" };

            var fakeRepositoryMock = new Mock<IPublishersRepository>();

            fakeRepositoryMock.Setup(x => x.Add(It.IsAny<Publishers>())).Callback<Publishers>(arg => pubs.Add(arg));

            var pubService = new PublishersService(fakeRepositoryMock.Object);

            await pubService.AddAndSave(pub3);


            Assert.Equal(3, pubs.Count);
        }

        [Fact]
        public async Task UpdateAndSaveTest()
        {
            var pub1 = new Publishers() { Pub_id = 1, Pub_name = "test pub 1" };
            var pub2 = new Publishers() { Pub_id = 2, Pub_name = "test pub 2" };
            var pubs = new List<Publishers> { pub1, pub2 };

            var newpub2 = new Publishers() { Pub_id = 2, Pub_name = "test pub 2" };

            var fakeRepositoryMock = new Mock<IPublishersRepository>();

            fakeRepositoryMock.Setup(x => x.Update(It.IsAny<Publishers>())).Callback<Publishers>(arg => pubs[1] = arg);

            var pubService = new PublishersService(fakeRepositoryMock.Object);

            await pubService.UpdateAndSave(newpub2);

            Assert.Equal("new test pub 2", pubs[1].Pub_name);
        }

        [Fact]
        public async Task DeleteAndSaveTest()
        {
            var pub1 = new Publishers() { Pub_id = 1, Pub_name = "test pub 1" };
            var pub2 = new Publishers() { Pub_id = 2, Pub_name = "test pub 2" };
            var pubs = new List<Publishers> { pub1, pub2 };

            var fakeRepositoryMock = new Mock<IPublishersRepository>();

            fakeRepositoryMock.Setup(x => x.Delete(It.IsAny<int>())).Callback<int>(arg => pubs.RemoveAt(1));

            var pubService = new PublishersService(fakeRepositoryMock.Object);

            await pubService.DeleteAndSave(pub2.Pub_id);

            Assert.Single(pubs);
            Assert.Equal("new test pub 1", pubs[0].Pub_name);
        }

        [Fact]
        public void ExistsTest()
        {
            var fakeRepositoryMock = new Mock<IPublishersRepository>();

            fakeRepositoryMock.Setup(x => x.PublisherExists(It.IsAny<int>())).Returns(true);

            var pubService = new PublishersService(fakeRepositoryMock.Object);

            bool result = pubService.PublisherExists(1);

            Assert.True(result);
        }
    }
}
