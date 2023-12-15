using BookStore.Infrastructure.Data;

namespace BookStore.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookStoreCodeFirstDbContext _db;
        
        public IShoppingCartRepository ShoppingCart { get; private set; }

        public IApplicationUserRepository ApplicationUser { get; private set; }

        public UnitOfWork(BookStoreCodeFirstDbContext db)
        {
            _db = db;
            ShoppingCart = new ShoppingCartRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);

        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
