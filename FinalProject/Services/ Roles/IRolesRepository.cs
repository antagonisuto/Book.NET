using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Services.Roles
{
    public interface IRolesRepository
    {
        Task<List<Models.Roles>> GetAll();

        Task<Models.Roles> GetByID(int Id);

        void Add(Models.Roles author);

        void Delete(int Id);

        void Update(Models.Roles author);

        Task Save();

        bool RoleExists(int id);
    }
}
