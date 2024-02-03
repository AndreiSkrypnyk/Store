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

		public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
		{
			var orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
			if (orderFromDb != null) {
				orderFromDb.OrderStatus = orderStatus;
				if (!string.IsNullOrEmpty(paymentStatus)) {
					orderFromDb.PaymentStatus = paymentStatus;
				}
			}
		}

		public void UpateStripePaymentID(int id, string sessionId, string paymentIntentId)
		{
			var orderFromDb = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
			if (!string.IsNullOrEmpty(sessionId)) {
				orderFromDb.SessionId = sessionId;
			}
			if (!string.IsNullOrEmpty(sessionId)) {
				orderFromDb.PaymentIntentId = paymentIntentId;
				orderFromDb.PaymentDate = DateTime.Now;
			}
		}
	}
}
