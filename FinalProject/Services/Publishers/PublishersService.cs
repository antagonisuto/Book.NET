using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Services.Publishers
{
    public class PublishersService
    {
        private readonly IPublishersRepository _pubRepo;

        public PublishersService(IPublishersRepository pubRepo)
        {
            _pubRepo = pubRepo;
        }

        public async Task<List<Models.Publishers>> GetAll()
        {
            return await _pubRepo.GetAll();
        }

        public async Task<Models.Publishers> GetById(string Id)
        {
            return await _pubRepo.GetByID(Id);
        }

        public async Task AddAndSave(Models.Publishers pub)
        {
            _pubRepo.Add(pub);
            await _pubRepo.Save();
        }

        public async Task UpdateAndSave(Models.Publishers pub)
        {
            _pubRepo.Update(pub);
            await _pubRepo.Save();
        }

        public async Task DeleteAndSave(string Id)
        {
            _pubRepo.Delete(Id);
            await _pubRepo.Save();
        }

        public bool PublisherExists(string id)
        {
            return _pubRepo.PublisherExists(id);
        }
    }
}
