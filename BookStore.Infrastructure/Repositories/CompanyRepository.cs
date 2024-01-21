using BookStore.Core.Entities;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.Repositories.IRepositories;

namespace BookStore.Infrastructure.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private BookStoreCodeFirstDbContext _db;
        public CompanyRepository(BookStoreCodeFirstDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company obj)
        {
            _db.Companies.Update(obj);
        }
    }
}
