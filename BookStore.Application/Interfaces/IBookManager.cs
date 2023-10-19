using BookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Interfaces
{
    public interface IBookManager
    {
        IList<Book> GetBooks();
        IList<Book> GetFeaturedBooks();
        Book GetBook(int id);
    }
}
