using BookStore.Core.Entities;

namespace BookStore.Infrastructure.Repositories.IRepositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company obj);
    }
}
