using BookStore.Core.Entities;
using BookStore.Infrastructure.Data;
using BookStore.Infrastructure.Repositories.IRepositories;

namespace BookStore.Infrastructure.Repositories
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private BookStoreCodeFirstDbContext _db;
        public OrderDetailRepository(BookStoreCodeFirstDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(OrderDetail obj)
        {
            _db.OrderDetails.Update(obj);
        }
    }
}
