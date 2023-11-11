using BookStore.Core.Entities;

namespace BookStore.Infrastructure.Repositories
{
    public interface IAccountRepository<T> : IDisposable
        where T : class
    {
        User FindUserByEmail(string name);
        Task<User> FindUserByEmailAsync(string name);
        void Create(T item); 
        void Update(T item); 
        void Delete(int id); 
        void Save(); 
    }
}
