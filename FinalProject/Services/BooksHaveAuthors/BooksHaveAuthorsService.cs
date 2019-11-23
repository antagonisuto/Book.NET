using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Services.Authors;
using FinalProject.Services.Books;

namespace FinalProject.Services.BooksHaveAuthors
{
    public class BooksHaveAuthorsService
    {
        private readonly IBooksHaveAuthorsRepository _bookAuRepo;
        private readonly IBooksRepository _bookRepo;
        private readonly IAuthorsRepository _auRepo;

        public BooksHaveAuthorsService(IBooksHaveAuthorsRepository bookAuRepo, IBooksRepository bookRepo, IAuthorsRepository auRepo)
        {
            _bookAuRepo = bookAuRepo;
            _bookRepo = bookRepo;
            _auRepo = auRepo;

        }

        public async Task<List<Models.BooksHaveAuthors>> GetAllBooksHaveAuthors()
        {
            return await _bookAuRepo.GetAll();
        }

        public async Task<List<Models.Books>> GetAllBooks()
        {
            return await _bookRepo.GetAll();
        }

        public async Task<List<Models.Authors>> GetAllAuthors()
        {
            return await _auRepo.GetAll();
        }

        public async Task<Models.BooksHaveAuthors> GetById(int Book_id, int Author_id)
        {
            return await _bookAuRepo.GetByID(Book_id, Author_id);
        }

        public async Task AddAndSave(Models.BooksHaveAuthors courseMember)
        {
            _bookAuRepo.Add(courseMember);
            await _bookAuRepo.Save();
        }

        public async Task UpdateAndSave(Models.BooksHaveAuthors courseMember)
        {
            _bookAuRepo.Update(courseMember);
            await _bookAuRepo.Save();
        }

        public async Task DeleteAndSave(int Book_id, int Author_id)
        {
            _bookAuRepo.Delete(Book_id, Author_id);
            await _bookAuRepo.Save();
        }

        public bool BooksHaveAuthorsExists(int Book_id, int Author_id)
        {
            return _bookAuRepo.BooksHaveAuthorsExists(Book_id, Author_id);
        }
    }
}