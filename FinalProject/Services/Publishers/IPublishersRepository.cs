using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Services.Publishers
{
    public interface IPublishersRepository
    {
        Task<List<Models.Publishers>> GetAll();

        Task<Models.Publishers> GetByID(string Id);

        void Add(Models.Publishers pub);

        void Delete(string Id);

        void Update(Models.Publishers pub);

        Task Save();

        bool PublisherExists(string id);
    }
}
