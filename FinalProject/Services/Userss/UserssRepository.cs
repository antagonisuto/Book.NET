using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Services.Userss
{
    public class UserssRepository : IUserssRepository
    {
        private readonly AppDBContext context;

        public UserssRepository(AppDBContext context)
        {
            this.context = context;
        }

        public void Add(Models.Userss user)
        {
            context.Userss.Add(user);
        }

        public void Delete(int Id)
        {
            Models.Userss user = context.Userss.Find(Id);
            context.Userss.Remove(user);
        }

        public Task<List<Models.Userss>> GetAll()
        {
            return context.Userss.Include(e => e.Role).ToListAsync();
        }

        public async Task<Models.Userss> GetByID(long Id)
        {
            return await context.Userss.Include(e => e.Role).FirstOrDefaultAsync(m => m.User_id == Id);
        }

        public Task Save()
        {
            return context.SaveChangesAsync();
        }

        public void Update(Models.Userss user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public bool UserExists(int id)
        {
            return context.Userss.Any(e => e.User_id == id);
        }
    }
}
