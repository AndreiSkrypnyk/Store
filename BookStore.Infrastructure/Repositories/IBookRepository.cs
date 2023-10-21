using BookStore.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    public interface IBookRepository<T> : IDisposable
        where T : class
    {
        List<T> GetBookList(); 
        List<T> GetFeaturedBook();
        Book GetBook(int id);
        List<Book> GetBookByName(string query);
        void Create(T item); 
        void Update(T item); 
        void Delete(int id); 
        void Save(); 
    }
}
