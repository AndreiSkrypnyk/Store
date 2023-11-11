using BookStore.Application.DTOs;
using BookStore.Core.Entities;

namespace BookStore.Application.Interfaces
{
    public interface IAccountManager
    {
        User FindUserByEmail(string email);
        Task<ManagerResult<User>> Login(string email, string password);
        Task<ManagerResult> Register(UserDTO userDTO);
    }
}
