using BookStore.Core.Entities;

namespace BookStore.Infrastructure.Repositories.IRepositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
    }
}
