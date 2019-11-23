using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Services.Books
{
    public interface IBooksRepository
    {
        Task<List<FinalProject.Models.Books>> GetAll();
        Task<FinalProject.Models.Books> GetByID(int Id);
        void Add(FinalProject.Models.Books book);
        void Delete(int Id);
        void Update(FinalProject.Models.Books book);
        Task Save();
        bool BookExists(int id);
    }
}
