using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace FinalProject.Services.BooksHaveAuthors
{
    public class BooksHaveAuthorsRepository : IBooksHaveAuthorsRepository
    {
        private readonly AppDBContext context;

        public BooksHaveAuthorsRepository(AppDBContext context)
        {
            this.context = context;
        }

        public void Add(Models.BooksHaveAuthors bookAu)
        {
            context.BooksHaveAuthors.Add(bookAu);
        }

        public bool BooksHaveAuthorsExists(string Book_id, string Author_id)
        {
            return context.BooksHaveAuthors.Any(e => e.Book_id == Book_id && e.Author_id == Author_id);
        }

        public void Delete(string Book_id, string Author_id)
        {
            Models.BooksHaveAuthors bookAu = context.BooksHaveAuthors.Find(Book_id, Author_id);
            context.BooksHaveAuthors.Remove(bookAu);
        }

        public Task<List<Models.BooksHaveAuthors>> GetAll()
        {
            return context.BooksHaveAuthors.Include(c => c.Book).Include(c => c.Authors).ToListAsync();
        }

        public async Task<Models.BooksHaveAuthors> GetByID(string Book_id, string Author_id)
        {
            return await context.BooksHaveAuthors.Include(c => c.Book).Include(d => d.Authors).FirstOrDefaultAsync(e => e.Book_id == Book_id && e.Author_id == Author_id);
        }

        public Task Save()
        {
            return context.SaveChangesAsync();
        }

        public void Update(Models.BooksHaveAuthors bookAu)
        {
            context.Entry(bookAu).State = EntityState.Modified;
        }
    }
}
