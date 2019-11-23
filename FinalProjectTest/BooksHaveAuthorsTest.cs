using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.Services.Authors;
using FinalProject.Services.Books;
using FinalProject.Services.BooksHaveAuthors;
using Moq;
using Xunit;

namespace FinalProjectTest
{
    public class BooksHaveAuthorsTest
    {
        [Fact]
        public async Task GetAllTest()
        {
            var BHA1 = new BooksHaveAuthors() { Book_id = 1, Author_id = 1 };
            var BHA2 = new BooksHaveAuthors() { Book_id = 2, Author_id = 2};
            var BHAs = new List<BooksHaveAuthors> { BHA1, BHA2 };

            var fakeBooksHaveAuthorsRepositoryMock = new Mock<IBooksHaveAuthorsRepository>();
            var fakeBooksRepositoryMock = new Mock<IBooksRepository>();
            var fakeAuthorRepositoryMock = new Mock<IAuthorsRepository>();

            fakeBooksHaveAuthorsRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(BHAs);

            var courseMemberService = new BooksHaveAuthorsService(fakeBooksHaveAuthorsRepositoryMock.Object, fakeBooksRepositoryMock.Object, fakeAuthorRepositoryMock.Object);

            var resultCourseMemberes = await courseMemberService.GetAllBooksHaveAuthors();

            Assert.Collection(resultCourseMemberes, courseMember =>
            {
                Assert.Equal(1, courseMember.Book_id);
            },
            courseMember =>
            {
                Assert.Equal(2, courseMember.Book_id);
            });
        }

        [Fact]
        public async Task GetByIdTest()
        {
            var BHA1 = new BooksHaveAuthors() { Book_id = 1, Author_id = 1};
            var BHA2 = new BooksHaveAuthors() { Book_id = 2, Author_id = 2};

            var fakeBooksHaveAuthorsRepositoryMock = new Mock<IBooksHaveAuthorsRepository>();
            var fakeBooksRepositoryMock = new Mock<IBooksRepository>(); var fakeAuthorRepositoryMock = new Mock<IAuthorsRepository>();

            fakeBooksHaveAuthorsRepositoryMock.Setup(x => x.GetByID(1, 1)).ReturnsAsync(BHA1);

            var courseMemberService = new BooksHaveAuthorsService(fakeBooksHaveAuthorsRepositoryMock.Object, fakeBooksRepositoryMock.Object, fakeAuthorRepositoryMock.Object);

            var result = await courseMemberService.GetById(1, 1);

            Assert.Equal(1, result.Book_id);
        }

        [Fact]
        public async Task AddAndSaveTest()
        {
            var BHA1 = new BooksHaveAuthors() { Book_id = 1, Author_id = 1};
            var BHA2 = new BooksHaveAuthors() { Book_id = 2, Author_id = 2};
            var BHAs = new List<BooksHaveAuthors> { BHA1, BHA2 };

            var BHA3 = new BooksHaveAuthors() { Book_id = 3, Author_id = 3};

            var fakeBooksHaveAuthorsRepositoryMock = new Mock<IBooksHaveAuthorsRepository>();
            var fakeBooksRepositoryMock = new Mock<IBooksRepository>(); var fakeAuthorRepositoryMock = new Mock<IAuthorsRepository>();

            fakeBooksHaveAuthorsRepositoryMock.Setup(x => x.Add(It.IsAny<BooksHaveAuthors>())).Callback<BooksHaveAuthors>(arg => BHAs.Add(arg));

            var courseMemberService = new BooksHaveAuthorsService(fakeBooksHaveAuthorsRepositoryMock.Object, fakeBooksRepositoryMock.Object, fakeAuthorRepositoryMock.Object);

            await courseMemberService.AddAndSave(BHA3);


            Assert.Equal(3, BHAs.Count);
        }

        [Fact]
        public async Task UpdateAndSaveTest()
        {
            var BHA1 = new BooksHaveAuthors() { Book_id = 1, Author_id = 1};
            var BHA2 = new BooksHaveAuthors() { Book_id = 2, Author_id = 2};
            var BHAs = new List<BooksHaveAuthors> { BHA1, BHA2 };

            var newCourseMember2 = new BooksHaveAuthors() { Book_id = 2, Author_id = 2};

            var fakeBooksHaveAuthorsRepositoryMock = new Mock<IBooksHaveAuthorsRepository>();
            var fakeBooksRepositoryMock = new Mock<IBooksRepository>(); var fakeAuthorRepositoryMock = new Mock<IAuthorsRepository>();

            fakeBooksHaveAuthorsRepositoryMock.Setup(x => x.Update(It.IsAny<BooksHaveAuthors>())).Callback<BooksHaveAuthors>(arg => BHAs[1] = arg);

            var courseMemberService = new BooksHaveAuthorsService(fakeBooksHaveAuthorsRepositoryMock.Object, fakeBooksRepositoryMock.Object, fakeAuthorRepositoryMock.Object);

            await courseMemberService.UpdateAndSave(newCourseMember2);

            Assert.Equal(2, BHAs[1].Book_id);
        }

        [Fact]
        public async Task DeleteAndSaveTest()
        {
            var BHA1 = new BooksHaveAuthors() { Book_id = 1, Author_id = 1};
            var BHA2 = new BooksHaveAuthors() { Book_id = 2, Author_id = 2};
            var BHAs = new List<BooksHaveAuthors> { BHA1, BHA2 };

            var fakeBooksHaveAuthorsRepositoryMock = new Mock<IBooksHaveAuthorsRepository>();
            var fakeBooksRepositoryMock = new Mock<IBooksRepository>(); var fakeAuthorRepositoryMock = new Mock<IAuthorsRepository>();

            fakeBooksHaveAuthorsRepositoryMock.Setup(x => x.Delete(It.IsAny<int>(), It.IsAny<int>())).Callback(() => BHAs.RemoveAt(1));

            var courseMemberService = new BooksHaveAuthorsService(fakeBooksHaveAuthorsRepositoryMock.Object, fakeBooksRepositoryMock.Object, fakeAuthorRepositoryMock.Object);

            await courseMemberService.DeleteAndSave(BHA2.Book_id, BHA2.Author_id);

            Assert.Single(BHAs);
            Assert.Equal(1, BHAs[0].Book_id);
        }

        [Fact]
        public void ExistsTest()
        {
            var fakeBooksHaveAuthorsRepositoryMock = new Mock<IBooksHaveAuthorsRepository>();
            var fakeBooksRepositoryMock = new Mock<IBooksRepository>(); var fakeAuthorRepositoryMock = new Mock<IAuthorsRepository>();

            fakeBooksHaveAuthorsRepositoryMock.Setup(x => x.BooksHaveAuthorsExists(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            var courseMemberService = new BooksHaveAuthorsService(fakeBooksHaveAuthorsRepositoryMock.Object, fakeBooksRepositoryMock.Object, fakeAuthorRepositoryMock.Object);

            bool result = courseMemberService.BooksHaveAuthorsExists(1, 1);

            Assert.True(result);
        }
    }
}
