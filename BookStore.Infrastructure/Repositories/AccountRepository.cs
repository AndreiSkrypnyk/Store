using BookStore.Core.Entities;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository<User> 
    {
        private readonly BookStoreCodeFirstDbContext _context;

        public AccountRepository(BookStoreCodeFirstDbContext context)
        {
            _context = context;
        }

        public User FindUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(x => x.Email == email);
        }

        public async Task<User> FindUserByEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Email == email);
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
        }
       
        public void Update(User user)
        {
            _context.Users.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User entity = _context.Users.Find(id);

            if (entity != null)
            {
                _context.Users.Attach(entity);
                _context.Entry(entity).State = EntityState.Deleted;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

