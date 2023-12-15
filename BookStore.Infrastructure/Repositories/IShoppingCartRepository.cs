using BookStore.Core.Entities;

namespace BookStore.Infrastructure.Repositories
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        void Update(ShoppingCart obj);
    }
}
