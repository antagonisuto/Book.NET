using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Services.BooksRequests
{
    public class BooksRequestsRepository : IBooksRequestsRepository
    {
        private readonly AppDBContext context;

        public BooksRequestsRepository(AppDBContext context)
        {
            this.context = context;
        }

        public void Add(Models.BooksRequests bookUser)
        {
            context.BooksRequests.Add(bookUser);
        }

        public bool BooksRequestsExists(string Book_id, string User_id)
        {
            return context.BooksInventories.Any(e => e.Book_id == Book_id && e.User_id == User_id);
        }

        public void Delete(string Book_id, string User_id)
        {
            Models.BooksRequests bookUser = context.BooksRequests.Find(Book_id, User_id);
            context.BooksRequests.Remove(bookUser);
        }

        public Task<List<Models.BooksRequests>> GetAll()
        {
            return context.BooksRequests.Include(c => c.Book).Include(c => c.User).ToListAsync();
        }

        public async Task<Models.BooksRequests> GetByID(string Book_id, string User_id)
        {
            return await context.BooksRequests.Include(c => c.Book).Include(c => c.User).FirstOrDefaultAsync(e => e.Book_id == Book_id && e.User_id == User_id);
        }

        public Task Save()
        {
            return context.SaveChangesAsync();
        }

        public void Update(Models.BooksRequests bookUser)
        {
            context.Entry(bookUser).State = EntityState.Modified;
        }
    }
}
