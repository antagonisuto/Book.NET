using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Services.Roles
{
    public struct RolesRepository : IRolesRepository
    {
        private readonly AppDBContext _context;

        public RolesRepository(AppDBContext context)
        {
            this._context = context;
        }

        public void Add(Models.Roles author)
        {
            _context.Roles.Add(author);
        }

        public void Delete(int Id)
        {
            FinalProject.Models.Roles author = _context.Roles.Find(Id);
            _context.Roles.Remove(author);
        }

        public Task<List<Models.Roles>> GetAll()
        {
            return _context.Roles.ToListAsync();
        }

        public async Task<Models.Roles> GetByID(int Id)
        {
            return await _context.Roles.FindAsync(Id);
        }

        public bool RoleExists(int id)
        {
            return _context.Roles.Any(e => e.Role_id == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(Models.Roles author)
        {
            _context.Entry(author).State = EntityState.Modified;
        }
    }
}
