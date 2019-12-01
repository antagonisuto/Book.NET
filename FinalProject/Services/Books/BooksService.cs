using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Services.Publishers;

namespace FinalProject.Services.Books
{
    public class BooksService
    {
        private readonly IBooksRepository _booksRepo;
        private readonly IPublishersRepository _pubRepo;

        public BooksService(IBooksRepository booksRepo, IPublishersRepository pubRepo)
        {
            _booksRepo = booksRepo;
            _pubRepo = pubRepo;

        }

        public async Task<List<Models.Books>> GetAllBooks()
        {
            return await _booksRepo.GetAll();
        }

        public async Task<List<Models.Publishers>> GetAllPublishers()
        {
            return await _pubRepo.GetAll();
        }

        public async Task<Models.Books> GetById(string Id)
        {
            return await _booksRepo.GetByID(Id);
        }

        public async Task AddAndSave(Models.Books book)
        {
            _booksRepo.Add(book);
            await _booksRepo.Save();
        }

        public async Task UpdateAndSave(Models.Books equipment)
        {
            _booksRepo.Update(equipment);
            await _booksRepo.Save();
        }

        public async Task DeleteAndSave(string Id)
        {
            _booksRepo.Delete(Id);
            await _booksRepo.Save();
        }

        public bool BookExists(string id)
        {
            return _booksRepo.BookExists(id);
        }

    }
}
