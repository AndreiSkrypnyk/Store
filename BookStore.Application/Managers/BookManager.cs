using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Managers
{
    public class BookManager
    {
        private readonly IServiceProvider _serviceProvider;
        public BookManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

    }
}
