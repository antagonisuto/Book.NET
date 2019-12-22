using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FinalProject.Services.Userss
{
    public interface IUserssRepository
    {
        Task<List<Models.Userss>> GetAll();
        Task<Models.Userss> GetByID(string Id);
        Task<Models.Userss> GetByEmail(string Email);
        void Add(Models.Userss equipment);
        void Delete(string Id);
        void Update(Models.Userss equipment);
        Task Save();
        bool UserExists(string id);
    }
}
