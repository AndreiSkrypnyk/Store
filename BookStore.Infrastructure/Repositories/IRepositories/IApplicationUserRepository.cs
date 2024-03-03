using BookStore.Core.Entities;

namespace BookStore.Infrastructure.Repositories.IRepositories
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        public void Update(ApplicationUser applicationUser);
    }
}
