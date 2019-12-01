using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Services.Books;
using FinalProject.Services.BooksHaveAuthors;
using FinalProject.Services.Userss;

namespace FinalProject.Services.BooksInventory
{
    public class BooksInventoryService
    {
        private readonly IBooksInventoryRepository _bookAuRepo;
        private readonly IBooksRepository _bookRepo;
        private readonly IUserssRepository _userRepo;

        public BooksInventoryService(IBooksInventoryRepository bookAuRepo, IBooksRepository bookRepo, IUserssRepository userRepo)
        {
            _bookAuRepo = bookAuRepo;
            _bookRepo = bookRepo;
            _userRepo = userRepo;

        }

        public async Task<List<Models.BooksInventory>> GetAllBooksInventory()
        {
            return await _bookAuRepo.GetAll();
        }

        public async Task<List<Models.Books>> GetAllBooks()
        {
            return await _bookRepo.GetAll();
        }

        public async Task<List<Models.Userss>> GetAllUsers()
        {
            return await _userRepo.GetAll();
        }

        public async Task<Models.BooksInventory> GetById(string Book_id, string User_id)
        {
            return await _bookAuRepo.GetByID(Book_id, User_id);
        }

        public async Task AddAndSave(Models.BooksInventory bookUser)
        {
            _bookAuRepo.Add(bookUser);
            await _bookAuRepo.Save();
        }

        public async Task UpdateAndSave(Models.BooksInventory bookUser)
        {
            _bookAuRepo.Update(bookUser);
            await _bookAuRepo.Save();
        }

        public async Task DeleteAndSave(string Book_id, string User_id)
        {
            _bookAuRepo.Delete(Book_id, User_id);
            await _bookAuRepo.Save();
        }

        public bool BooksInventoryExists(string Book_id, string User_id)
        {
            return _bookAuRepo.BooksInventoryExists(Book_id, User_id);
        }
    }
}
