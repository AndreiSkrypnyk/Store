using BookStore.Application.Interfaces;
using BookStore.Core.Entities;
using BookStore.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Managers
{
    public class BookManager: IBookManager
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IRepository<Book> _bookRepository;

        public BookManager(IServiceProvider serviceProvider, IRepository<Book> bookRepository)
        {
            _serviceProvider = serviceProvider;
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
    }
}
