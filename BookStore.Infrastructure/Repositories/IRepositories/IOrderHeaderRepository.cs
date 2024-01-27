using BookStore.Core.Entities;

namespace BookStore.Infrastructure.Repositories.IRepositories
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader obj);
    }
}
