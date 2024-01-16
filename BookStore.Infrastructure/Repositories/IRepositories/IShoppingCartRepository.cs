using BookStore.Core.Entities;

namespace BookStore.Infrastructure.Repositories.IRepositories
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        void Update(ShoppingCart obj);
    }
}
