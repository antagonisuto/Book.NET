using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Services.BooksInventory
{
    public class BooksInventoryRepository : IBooksInventoryRepository
    {
        private readonly AppDBContext context;

        public BooksInventoryRepository(AppDBContext context)
        {
            this.context = context;
        }

        public void Add(Models.BooksInventory bookUser)
        {
            context.BooksInventories.Add(bookUser);
        }

        public bool BooksInventoryExists(int Book_id, int User_id)
        {
            return context.BooksInventories.Any(e => e.Book_id == Book_id && e.User_id == User_id);
        }

        public void Delete(int Book_id, int User_id)
        {
            Models.BooksInventory bookUser = context.BooksInventories.Find(Book_id, User_id);
            context.BooksInventories.Remove(bookUser);
        }

        public Task<List<Models.BooksInventory>> GetAll()
        {
            return context.BooksInventories.Include(c => c.Book).Include(c => c.User).ToListAsync();
        }

        public async Task<Models.BooksInventory> GetByID(int Book_id, int User_id)
        {
            return await context.BooksInventories.Include(c => c.Book).Include(c => c.User).FirstOrDefaultAsync(e => e.Book_id == Book_id && e.User_id == User_id);
        }

        public Task Save()
        {
            return context.SaveChangesAsync();
        }

        public void Update(Models.BooksInventory bookUser)
        {
            context.Entry(bookUser).State = EntityState.Modified;
        }
    }
}
