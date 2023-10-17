using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> 
        where T : class
    {
        private readonly BookStoreCodeFirstDbContext _context;
        private DbSet<T> _dbSet;

        public Repository(BookStoreCodeFirstDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public List<T> GetBookList()
        {
            return _dbSet.ToList();
        }
        public T GetBook(int id)
        {
            return _dbSet.Find(id);
        }

        public List<T> GetFeaturedBook()
        {
            return _dbSet.Take(3).ToList();
        }

        public void Create(T item)
        {
            _dbSet.Add(item);
        }
        public void Update(T item)
        {
            _dbSet.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            T entity = _dbSet.Find(id);
            if (entity != null)
                _dbSet.Remove(entity);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

