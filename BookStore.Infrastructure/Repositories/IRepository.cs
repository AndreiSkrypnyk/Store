using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        List<T> GetBookList(); 
        List<T> GetFeaturedBook();
        Book GetBook(int id);
        void Create(T item); 
        void Update(T item); 
        void Delete(int id); 
        void Save(); 
    }
}
