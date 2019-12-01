using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Services.Books;
using FinalProject.Services.Userss;

namespace FinalProject.Services.BooksRequests
{
    public class BooksRequestsService
    {
        private readonly IBooksRequestsRepository _bookReRepo;
        private readonly IBooksRepository _bookRepo;
        private readonly IUserssRepository _userRepo;

        public BooksRequestsService(IBooksRequestsRepository bookAuRepo, IBooksRepository bookRepo, IUserssRepository userRepo)
        {
            _bookReRepo = bookAuRepo;
            _bookRepo = bookRepo;
            _userRepo = userRepo;

        }

        public async Task<List<Models.BooksRequests>> GetAllBooksRequests()
        {
            return await _bookReRepo.GetAll();
        }

        public async Task<List<Models.Books>> GetAllBooks()
        {
            return await _bookRepo.GetAll();
        }

        public async Task<List<Models.Userss>> GetAllUsers()
        {
            return await _userRepo.GetAll();
        }

        public async Task<Models.BooksRequests> GetById(string Book_id, string User_id)
        {
            return await _bookReRepo.GetByID(Book_id, User_id);
        }

        public async Task AddAndSave(Models.BooksRequests bookUser)
        {
            _bookReRepo.Add(bookUser);
            await _bookReRepo.Save();
        }

        public async Task UpdateAndSave(Models.BooksRequests bookUser)
        {
            _bookReRepo.Update(bookUser);
            await _bookReRepo.Save();
        }

        public async Task DeleteAndSave(string Book_id, string User_id)
        {
            _bookReRepo.Delete(Book_id, User_id);
            await _bookReRepo.Save();
        }

        public bool BooksRequestsExists(string Book_id, string User_id)
        {
            return _bookReRepo.BooksRequestsExists(Book_id, User_id);
        }
    }
}
