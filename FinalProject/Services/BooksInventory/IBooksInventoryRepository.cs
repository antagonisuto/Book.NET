using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Services.BooksInventory
{
    public interface IBooksInventoryRepository
    {
        Task<List<Models.BooksInventory>> GetAll();
        Task<Models.BooksInventory> GetByID(string Book_id, string User_id);
        void Add(Models.BooksInventory bookUser);
        void Delete(string Book_id, string User_id);
        void Update(Models.BooksInventory bookUser);
        Task Save();
        bool BooksInventoryExists(string Book_id, string User_id);
    }
}
