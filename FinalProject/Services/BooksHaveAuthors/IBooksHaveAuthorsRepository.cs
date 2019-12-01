using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Services.BooksHaveAuthors
{
    public interface IBooksHaveAuthorsRepository
    {
        Task<List<Models.BooksHaveAuthors>> GetAll();
        Task<Models.BooksHaveAuthors> GetByID(string Book_id, string Author_id);
        void Add(Models.BooksHaveAuthors bookAu);
        void Delete(string Book_id, string Author_id);
        void Update(Models.BooksHaveAuthors bookAu);
        Task Save();
        bool BooksHaveAuthorsExists(string Book_id, string Author_id);
    }
}
