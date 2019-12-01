using System;
using Xunit;
using FinalProject.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using FinalProject.Services.Authors;
using Moq;

public class AuthorsTest
{
    [Fact]
    public async Task GetAllTask() {

        var author1 = new Authors() { Author_id = "1", Author_name = "test author 1" };
        var author2 = new Authors() { Author_id = "2", Author_name = "test author 2"};
        var authors = new List<Authors> { author1, author2 };

        var fakeRepositoryMock = new Mock<IAuthorsRepository>();

        fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(authors);

        var coachService = new AuthorsService(fakeRepositoryMock.Object);

        var resultAuthors = await coachService.GetAll();

        Assert.Collection(resultAuthors, author =>
        {
            Assert.Equal("test author 1", author.Author_name);
        },
        author =>
        {
            Assert.Equal("test author 2", author.Author_name);
        });

    }

    [Fact]
    public async Task GetByIdTest()
    {
        var author1 = new Authors() { Author_id = "1", Author_name = "test author 1" };
        var author2 = new Authors() { Author_id = "2", Author_name = "test author 2" };

        var fakeRepositoryMock = new Mock<IAuthorsRepository>();

        fakeRepositoryMock.Setup(x => x.GetByID("1")).ReturnsAsync(author1);

        var authorService = new AuthorsService(fakeRepositoryMock.Object);

        var result = await authorService.GetById("1");

        Assert.Equal("test author 1", result.Author_name);
    }

    [Fact]
    public async Task AddAndSaveTest()
    {
        var author1 = new Authors() { Author_id = "1", Author_name = "test author 1" };
        var author2 = new Authors() { Author_id = "2", Author_name = "test author 2" };
        var authors = new List<Authors> { author1, author2 };

        var author3 = new Authors() { Author_id = "3", Author_name = "test author 3" };

        var fakeRepositoryMock = new Mock<IAuthorsRepository>();

        fakeRepositoryMock.Setup(x => x.Add(It.IsAny<Authors>())).Callback<Authors>(arg => authors.Add(arg));

        var coachService = new AuthorsService(fakeRepositoryMock.Object);

        await coachService.AddAndSave(author3);


        Assert.Equal(3, authors.Count);
    }

    [Fact]
    public async Task UpdateAndSaveTest()
    {
        var author1 = new Authors() { Author_id = "1", Author_name = "test author 1" };
        var author2 = new Authors() { Author_id = "2", Author_name = "test author 2" };
        var authors = new List<Authors> { author1, author2 };

        var newAuthor2 = new Authors() { Author_id = "2", Author_name = "new test author 2" };

        var fakeRepositoryMock = new Mock<IAuthorsRepository>();

        fakeRepositoryMock.Setup(x => x.Update(It.IsAny<Authors>())).Callback<Authors>(arg => authors[1] = arg);

        var coachService = new AuthorsService(fakeRepositoryMock.Object);

        await coachService.UpdateAndSave(newAuthor2);

        Assert.Equal("new test author 2", authors[1].Author_name);
    }

    [Fact]
    public async Task DeleteAndSaveTest()
    {
        var author1 = new Authors() { Author_id = "1", Author_name = "test author 1" };
        var author2 = new Authors() { Author_id = "2", Author_name = "test author 2" };
        var authors = new List<Authors> { author1, author2 };

        var fakeRepositoryMock = new Mock<IAuthorsRepository>();

        fakeRepositoryMock.Setup(x => x.Delete(It.IsAny<string>())).Callback<int>(arg => authors.RemoveAt(1));

        var coachService = new AuthorsService(fakeRepositoryMock.Object);

        await coachService.DeleteAndSave(author2.Author_id);

        Assert.Single(authors);
        Assert.Equal("test author 1", authors[0].Author_name);
    }

    [Fact]
    public void ExistsTest()
    {
        var fakeRepositoryMock = new Mock<IAuthorsRepository>();

        fakeRepositoryMock.Setup(x => x.AuthorExists(It.IsAny<string>())).Returns(true);

        var coachService = new AuthorsService(fakeRepositoryMock.Object);

        bool result = coachService.CoachExists("1");

        Assert.True(result);
    }

}
