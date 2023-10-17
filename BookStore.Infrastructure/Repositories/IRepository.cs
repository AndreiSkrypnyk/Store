namespace BookStore.Infrastructure.Repositories
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        List<T> GetBookList(); 
        T GetBook(int id);
        List<T> GetFeaturedBook();
        void Create(T item); 
        void Update(T item); 
        void Delete(int id); 
        void Save(); 
    }
}
