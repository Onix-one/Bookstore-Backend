using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bookstore.IdentityApi.Dto;
using Microsoft.AspNetCore.Identity;

namespace Bookstore.IdentityApi.Interfaces
{
    public interface IUserService
    {
        Task<Tuple<IEnumerable<UserDto>, IdentityResult>> GetAllUsersAsync();
        Task<Tuple<UserDto, IdentityResult>> GetUserByIdAsync(string id);
        Task<Tuple<UserDto, IdentityResult>> CreateUserAsync(CreateUserDto modelDto);
        Task<Tuple<UserDto, IdentityResult>> CreateUserWithRandomPassAsync(UserDto userDto);
        Task<IdentityResult> EditUserAsync(UserDto userDto);
        Task<IdentityResult> DeleteUserAsync(string id);
        Task<Tuple<IEnumerable<string>, IdentityResult>> GetRolesAsync();
    }
}
