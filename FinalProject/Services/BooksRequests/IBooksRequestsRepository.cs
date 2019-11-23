using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject.Services.BooksRequests
{
    public interface IBooksRequestsRepository
    {
        Task<List<Models.BooksRequests>> GetAll();
        Task<Models.BooksRequests> GetByID(int Book_id, int User_id);
        void Add(Models.BooksRequests bookUser);
        void Delete(int Book_id, int User_id);
        void Update(Models.BooksRequests bookUser);
        Task Save();
        bool BooksRequestsExists(int Book_id, int User_id);
    }
}
