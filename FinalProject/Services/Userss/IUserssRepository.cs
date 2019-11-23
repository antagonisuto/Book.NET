using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FinalProject.Services.Userss
{
    public interface IUserssRepository
    {
        Task<List<Models.Userss>> GetAll();
        Task<Models.Userss> GetByID(long Id);
        void Add(Models.Userss equipment);
        void Delete(int Id);
        void Update(Models.Userss equipment);
        Task Save();
        bool UserExists(int id);
    }
}
