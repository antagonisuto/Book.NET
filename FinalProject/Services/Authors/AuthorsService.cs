using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.Services.Authors;

namespace FinalProject.Services.Authors
{

    public class AuthorsService
    {
        private readonly IAuthorsRepository _authorRepo;

        public AuthorsService(IAuthorsRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }

        public async Task<List<FinalProject.Models.Authors>> GetAll()
        {
            return await _authorRepo.GetAll();
        }

        public async Task<FinalProject.Models.Authors> GetById(int Id)
        {
            return await _authorRepo.GetByID(Id);
        }

        public async Task AddAndSave(FinalProject.Models.Authors author)
        {
            _authorRepo.Add(author);
            await _authorRepo.Save();
        }

        public async Task UpdateAndSave(FinalProject.Models.Authors author)
        {
            _authorRepo.Update(author);
            await _authorRepo.Save();
        }

        public async Task DeleteAndSave(int Id)
        {
            _authorRepo.Delete(Id);
            await _authorRepo.Save();
        }

        public bool CoachExists(int id)
        {
            return _authorRepo.AuthorExists(id);
        }
    }
}