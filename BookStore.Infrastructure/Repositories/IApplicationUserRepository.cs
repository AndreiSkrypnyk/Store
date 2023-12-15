using BookStore.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Repositories
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
    }
}
