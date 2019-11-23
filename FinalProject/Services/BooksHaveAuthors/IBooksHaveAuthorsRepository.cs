using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Services.BooksHaveAuthors
{
    public interface IBooksHaveAuthorsRepository
    {
        Task<List<Models.BooksHaveAuthors>> GetAll();
        Task<Models.BooksHaveAuthors> GetByID(int Book_id, int Author_id);
        void Add(Models.BooksHaveAuthors bookAu);
        void Delete(int Book_id, int Author_id);
        void Update(Models.BooksHaveAuthors bookAu);
        Task Save();
        bool BooksHaveAuthorsExists(int Book_id, int Author_id);
    }
}
