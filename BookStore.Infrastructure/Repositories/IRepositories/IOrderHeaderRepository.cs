using BookStore.Core.Entities;

namespace BookStore.Infrastructure.Repositories.IRepositories
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader obj);
        void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);
        void UpateStripePaymentID(int id, string sessionId, string paymentIntentId);
    }
}
