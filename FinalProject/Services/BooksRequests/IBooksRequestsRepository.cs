using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Services.BooksRequests
{
    public interface IBooksRequestsRepository
    {
        Task<List<Models.BooksRequests>> GetAll();
        Task<Models.BooksRequests> GetByID(string Book_id, string User_id);
        void Add(Models.BooksRequests bookUser);
        void Delete(string Book_id, string User_id);
        void Update(Models.BooksRequests bookUser);
        Task Save();
        bool BooksRequestsExists(string Book_id, string User_id);
    }
}
