using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.Services.Books;
using FinalProject.Services.Publishers;
using Moq;
using Xunit;

namespace FinalProjectTest
{
    public class BooksTest
    {
        [Fact]
        public async Task GetAllTest()
        {
            var Books1 = new Books() { Book_id = "1", Book_title = "test Books 1", Book_shortDec = "test Book short 1", Book_dec = "test dec 1", Book_page = 1, Pub_id = "1" };
            var Books2 = new Books() { Book_id = "2", Book_title = "test Books 2", Book_shortDec = "test Book short 2", Book_dec = "test dec 2", Book_page = 2, Pub_id = "2" };
            var books = new List<Books> { Books1, Books2 };

            var fakeBooksRepositoryMock = new Mock<IBooksRepository>();
            var fakeRoomRepositoryMock = new Mock<IPublishersRepository>();

            fakeBooksRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(books);

            var BooksService = new BooksService(fakeBooksRepositoryMock.Object, fakeRoomRepositoryMock.Object);

            var resultBookses = await BooksService.GetAllBooks();

            Assert.Collection(resultBookses, Books =>
            {
                Assert.Equal("test Books 1", Books.Book_title);
            },
            Books =>
            {
                Assert.Equal("test Books 2", Books.Book_title);
            });
        }

        [Fact]
        public async Task GetByBook_idTest()
        {
            var Books1 = new Books() { Book_id = "1", Book_title = "test Books 1", Book_shortDec = "test Book short 1", Book_dec = "test dec 1", Book_page = 1, Pub_id = "1" };
            var Books2 = new Books() { Book_id = "2", Book_title = "test Books 2", Book_shortDec = "test Book short 2", Book_dec = "test dec 2", Book_page = 2, Pub_id = "2" };

            var fakeBooksRepositoryMock = new Mock<IBooksRepository>();
            var fakeRoomRepositoryMock = new Mock<IPublishersRepository>();

            fakeBooksRepositoryMock.Setup(x => x.GetByID("1")).ReturnsAsync(Books1);

            var BooksService = new BooksService(fakeBooksRepositoryMock.Object, fakeRoomRepositoryMock.Object);

            var result = await BooksService.GetById("1");

            Assert.Equal("test Books 1", result.Book_title);
        }

        [Fact]
        public async Task AddAndSaveTest()
        {
            var Books1 = new Books() { Book_id = "1", Book_title = "test Books 1", Book_shortDec = "test Book short 1", Book_dec = "test dec 1", Book_page = 1, Pub_id = "1" };
            var Books2 = new Books() { Book_id = "2", Book_title = "test Books 2", Book_shortDec = "test Book short 2", Book_dec = "test dec 2", Book_page = 2, Pub_id = "2" };
            var books = new List<Books> { Books1, Books2 };

            var Books3 = new Books() { Book_id = "3", Book_title = "test Books 3", Book_shortDec = "test Book short 3", Book_dec = "test dec 3", Book_page = 3, Pub_id = "3" };

            var fakeBooksRepositoryMock = new Mock<IBooksRepository>();
            var fakeRoomRepositoryMock = new Mock<IPublishersRepository>();

            fakeBooksRepositoryMock.Setup(x => x.Add(It.IsAny<Books>())).Callback<Books>(arg => books.Add(arg));

            var BooksService = new BooksService(fakeBooksRepositoryMock.Object, fakeRoomRepositoryMock.Object);

            await BooksService.AddAndSave(Books3);


            Assert.Equal(3, books.Count);
        }

        [Fact]
        public async Task UpdateAndSaveTest()
        {
            var Books1 = new Books() { Book_id = "1", Book_title = "test Books 1", Book_shortDec = "test Book short 1", Book_dec = "test dec 1", Book_page = 1, Pub_id = "1" };
            var Books2 = new Books() { Book_id = "2", Book_title = "test Books 2", Book_shortDec = "test Book short 2", Book_dec = "test dec 2", Book_page = 2, Pub_id = "2" };
            var books = new List<Books> { Books1, Books2 };

            var newBooks2 = new Books() { Book_id = "3", Book_title = "test Books 2", Book_shortDec = "test Book short 2", Book_dec = "test dec 2", Book_page = 2, Pub_id = "2" };

            var fakeBooksRepositoryMock = new Mock<IBooksRepository>();
            var fakeRoomRepositoryMock = new Mock<IPublishersRepository>();

            fakeBooksRepositoryMock.Setup(x => x.Update(It.IsAny<Books>())).Callback<Books>(arg => books[1] = arg);

            var BooksService = new BooksService(fakeBooksRepositoryMock.Object, fakeRoomRepositoryMock.Object);

            await BooksService.UpdateAndSave(newBooks2);

            Assert.Equal("test Books 2", books[1].Book_title);
        }

        [Fact]
        public async Task DeleteAndSaveTest()
        {
            var Books1 = new Books() { Book_id = "1", Book_title = "test Books 1", Book_shortDec = "test Book short 1", Book_dec = "test dec 1", Book_page = 1, Pub_id = "1" };
            var Books2 = new Books() { Book_id = "2", Book_title = "test Books 2", Book_shortDec = "test Book short 2", Book_dec = "test dec 2", Book_page = 2, Pub_id = "2" };
            var books = new List<Books> { Books1, Books2 };

            var fakeBooksRepositoryMock = new Mock<IBooksRepository>();
            var fakeRoomRepositoryMock = new Mock<IPublishersRepository>();

            fakeBooksRepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Callback<string>(arg => books.RemoveAt(1));

            var BooksService = new BooksService(fakeBooksRepositoryMock.Object, fakeRoomRepositoryMock.Object);

            await BooksService.DeleteAndSave(Books2.Book_id);

            Assert.Single(books);
            Assert.Equal("test Books 1", books[0].Book_title);
        }

        [Fact]
        public void ExistsTest()
        {
            var fakeBooksRepositoryMock = new Mock<IBooksRepository>();
            var fakeRoomRepositoryMock = new Mock<IPublishersRepository>();

            fakeBooksRepositoryMock.Setup(x => x.BookExists(It.IsAny<string>())).Returns(true);

            var BooksService = new BooksService(fakeBooksRepositoryMock.Object, fakeRoomRepositoryMock.Object);

            bool result = BooksService.BookExists("1");

            Assert.True(result);
        }
    }
}
