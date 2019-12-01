using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Services.Books
{
    public class BooksRepository : IBooksRepository
    {
        private readonly AppDBContext context;

        public BooksRepository(AppDBContext context)
        {
            this.context = context;
        }

        public void Add(Models.Books book)
        {
            context.Books.Add(book);
        }

        public bool BookExists(string id)
        {
            return context.Books.Any(e => e.Book_id == id);
        }

        public void Delete(string Id)
        {
            FinalProject.Models.Books book = context.Books.Find(Id);
            context.Books.Remove(book);
        }

        public Task<List<Models.Books>> GetAll()
        {
            return context.Books.Include(e => e.Publishers).ToListAsync();
        }

        public async Task<Models.Books> GetByID(string Id)
        {
            return await context.Books.Include(e => e.Publishers).FirstOrDefaultAsync(m => m.Book_id == Id);
        }

        public Task Save()
        {
            return context.SaveChangesAsync();
        }

        public void Update(Models.Books book)
        {
            context.Entry(book).State = EntityState.Modified;
        }
    }
}
