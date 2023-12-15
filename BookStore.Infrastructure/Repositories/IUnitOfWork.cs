namespace BookStore.Infrastructure.Repositories
{
    public interface IUnitOfWork
    {
        IShoppingCartRepository ShoppingCart { get; }
        IApplicationUserRepository ApplicationUser { get; }
        void Save();
    }
}
