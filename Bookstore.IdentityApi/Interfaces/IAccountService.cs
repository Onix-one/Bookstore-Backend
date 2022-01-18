using System;
using System.Threading.Tasks;
using Bookstore.IdentityApi.Dto;
using Bookstore.IdentityApi.Models;
using Microsoft.AspNetCore.Identity;

namespace Bookstore.IdentityApi.Interfaces
{
    public interface IAccountService
    {
        public Task<Tuple<User, IdentityResult>> RegistrationAsync(RegistrationDto modelDto);
        public Task<Tuple<string, IdentityResult>> LoginAsync(LoginDto modelDto);
        public Task<IdentityResult> ChangePasswordAsync(ChangePasswordDto modelDto);
        public Task<bool> CheckUserExistsAsync(RegistrationDto modelDto);
        public Task<UserDto> GetCurrentUserAsync(User user);
    }
}
