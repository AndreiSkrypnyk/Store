using BookStore.Application.Interfaces;
using BookStore.Core.Entities;
using BookStore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Managers
{
    public class BookManager: IBookManager
    {
        private readonly IRepository<Book> _bookRepository;

        public BookManager(IRepository<Book> bookRepository)
        {    
            _bookRepository = bookRepository;
        }

        public IList<Book> GetBooks()
        {
            var books = _bookRepository.GetBookList();
            return books;
        }

        public IList<Book> GetFeaturedBooks()
        {
            var books = _bookRepository.GetFeaturedBook();
            return books;
        }

        public Book GetBook(int id)
        {
            var book = _bookRepository.GetBook(id);
            return book;
        }

        public IList<Book> GetBookByName(string query)
        {
            var books = _bookRepository.GetBookByName(query);
            return books;
        }
    }
}
