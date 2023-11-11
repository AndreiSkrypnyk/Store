using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Core.Entities;
using BookStore.Infrastructure.Repositories;

namespace BookStore.Application.Managers
{
    public class AccountManager: IAccountManager
    {
        private readonly IAccountRepository<User> _accountRepository;
        public AccountManager(IAccountRepository<User> accountRepository)
        {    
            _accountRepository = accountRepository;
        }

        public User FindUserByEmail(string email)
        {
            var user = _accountRepository.FindUserByEmail(email);
            return user;
        }
        public async Task<ManagerResult<User>> Login(string email, string password)
        {
            var result = new ManagerResult<User>();
            result.Data = await _accountRepository.FindUserByEmailAsync(email);

            if (result.Data == null)
            {
                result.Message = ErrorMessages.EmailNotFound;
                result.Success = false;
                return result;
            }

            if (result.Data.Password != password)
            {
                result.Message = ErrorMessages.WrongPassword;
                result.Success = false;
                return result;
            }

            result.Success = true;
            return result;
        }
        public async Task<ManagerResult> Register(UserDTO userDTO)
        {
            var result = new ManagerResult();
            var existingUser = await _accountRepository.FindUserByEmailAsync(userDTO.Email);
            if (existingUser != null)
            {
                result.Message = "Email is already in use";
                result.Success = false;
                return result;
            }
            else
            {
                var newUser = new User
                {
                    UserName = userDTO.UserName,
                    Email = userDTO.Email,
                    Password = userDTO.Password,
                    Role = Role.Customer
                };

                _accountRepository.Create(newUser);
                _accountRepository.Save();
            }
            result.Success = true;
            return result;
        }
    }
}
