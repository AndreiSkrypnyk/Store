using BookStore.Core.Entities;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.Repositories.IRepositories;

namespace BookStore.Infrastructure.Repositories
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private BookStoreCodeFirstDbContext _db;
        public OrderHeaderRepository(BookStoreCodeFirstDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderHeader obj)
        {
            _db.OrderHeaders.Update(obj);
        }
    }
}
