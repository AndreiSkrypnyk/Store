using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.Repositories.IRepositories;

namespace BookStore.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookStoreCodeFirstDbContext _db;

        public ICategoryRepository Category { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IProductRepository Product { get; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }

        public UnitOfWork(BookStoreCodeFirstDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Company = new CompanyRepository(_db);
            Product = new ProductRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);

        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
