using BookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Repositories.IRepositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}
