using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Services.BooksInventory
{
    public interface IBooksInventoryRepository
    {
        Task<List<Models.BooksInventory>> GetAll();
        Task<Models.BooksInventory> GetByID(int Book_id, int User_id);
        void Add(Models.BooksInventory bookUser);
        void Delete(int Book_id, int User_id);
        void Update(Models.BooksInventory bookUser);
        Task Save();
        bool BooksInventoryExists(int Book_id, int User_id);
    }
}
