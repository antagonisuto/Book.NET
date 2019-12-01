using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Services.Publishers
{
    public class PublishersRepository : IPublishersRepository
    {
        private readonly AppDBContext context;

        public PublishersRepository(AppDBContext context)
        {
            this.context = context;
        }

        public void Add(Models.Publishers pub)
        {
            context.Publishers.Add(pub);
        }

        public bool PublisherExists(string id)
        {
            return context.Publishers.Any(e => e.Pub_id == id);
        }

        public void Delete(string Id)
        {
            Models.Publishers pub = context.Publishers.Find(Id);
            context.Publishers.Remove(pub);
        }

        public Task<List<Models.Publishers>> GetAll()
        {
            return context.Publishers.ToListAsync();
        }

        public async Task<Models.Publishers> GetByID(string Id)
        {
            return await context.Publishers.FindAsync(Id);
        }

        public Task Save()
        {
            return context.SaveChangesAsync();
        }

        public void Update(Models.Publishers pub)
        {
            context.Entry(pub).State = EntityState.Modified;
        }

    }
}
