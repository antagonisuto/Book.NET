using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject.Models;


namespace FinalProject.Services.Authors
{
    public interface IAuthorsRepository
    {
        Task<List<Models.Authors>> GetAll();

        Task<Models.Authors> GetByID(int Id);

        void Add(Models.Authors author);

        void Delete(int Id);

        void Update(Models.Authors author);

        Task Save();

        bool AuthorExists(int id);
    }
}