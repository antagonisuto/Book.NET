using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Services.Roles
{
    public class RolesService
    {
        private readonly IRolesRepository _authorRepo;

        public RolesService(IRolesRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }

        public async Task<List<Models.Roles>> GetAll()
        {
            return await _authorRepo.GetAll();
        }

        public async Task<Models.Roles> GetById(int Id)
        {
            return await _authorRepo.GetByID(Id);
        }

        public async Task AddAndSave(Models.Roles author)
        {
            _authorRepo.Add(author);
            await _authorRepo.Save();
        }

        public async Task UpdateAndSave(FinalProject.Models.Roles author)
        {
            _authorRepo.Update(author);
            await _authorRepo.Save();
        }

        public async Task DeleteAndSave(int Id)
        {
            _authorRepo.Delete(Id);
            await _authorRepo.Save();
        }

        public bool RoleExists(int id)
        {
            return _authorRepo.RoleExists(id);
        }
    }
}
