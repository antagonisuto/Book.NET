using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Services.Publishers
{
    public interface IPublishersRepository
    {
        Task<List<Models.Publishers>> GetAll();

        Task<Models.Publishers> GetByID(int Id);

        void Add(Models.Publishers pub);

        void Delete(int Id);

        void Update(Models.Publishers pub);

        Task Save();

        bool PublisherExists(int id);
    }
}
