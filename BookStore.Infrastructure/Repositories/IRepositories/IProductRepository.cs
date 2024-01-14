using BookStore.Core.Entities;

namespace BookStore.Infrastructure.Repositories.IRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product category);
    }
}
