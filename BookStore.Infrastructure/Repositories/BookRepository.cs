using BookStore.Core.Entities;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository<Book> 
    {
        private readonly BookStoreCodeFirstDbContext _context;

        public BookRepository(BookStoreCodeFirstDbContext context)
        {
            _context = context;
        }
        public List<Book> GetBookList()
        {
            return _context.Books.ToList();
        }
        public Book GetBook(int id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id);
        }

        public List<Book> GetFeaturedBook()
        {
            return _context.Books.Take(3).ToList();
        }

        public List<Book> GetBookByName(string query)
        {
            return _context.Books.Where(x => x.Title.Contains(query)).ToList();
        }

        public void Create(Book item)
        {
            _context.Books.Add(item);
        }
        public void Update(Book item)
        {
            _context.Books.Attach(item);
            _context.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Book entity = _context.Books.Find(id);

            if (entity != null)
            {
                _context.Books.Attach(entity);
                _context.Entry(entity).State = EntityState.Deleted;
            }
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

