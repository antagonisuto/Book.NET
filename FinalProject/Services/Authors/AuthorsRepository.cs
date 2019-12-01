using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Services.Authors
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly AppDBContext _context;

        public AuthorsRepository(AppDBContext context)
        {
            this._context = context;
        }

        public void Add(FinalProject.Models.Authors author)
        {
            _context.Authors.Add(author);
        }

        public bool AuthorExists(string id)
        {
            return _context.Authors.Any(e => e.Author_id == id);
        }

        public void Delete(string Id)
        {
            FinalProject.Models.Authors author = _context.Authors.Find(Id);
            _context.Authors.Remove(author);
        }

        public Task<List<FinalProject.Models.Authors>> GetAll()
        {
            return _context.Authors.ToListAsync();
        }

        public async Task<FinalProject.Models.Authors> GetByID(string Id)
        {
            return await _context.Authors.FindAsync(Id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(FinalProject.Models.Authors author)
        {
            _context.Entry(author).State = EntityState.Modified;
        }

    }
}