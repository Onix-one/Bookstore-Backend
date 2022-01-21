using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bookstore.IdentityApi.Dto;
using Bookstore.IdentityApi.Interfaces;
using Bookstore.IdentityApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.IdentityApi.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public UserService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,
            IMapper mapper, INotificationService notificationService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _notificationService = notificationService;
        }


        public async Task<Tuple<IEnumerable<UserDto>, IdentityResult>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            if (users == null)
            {
                return new Tuple<IEnumerable<UserDto>, IdentityResult>(default, IdentityResult.Failed());
            }
            var usersDto = new List<UserDto>();
            foreach (var user in users)
            {
                var userDto = _mapper.Map<UserDto>(user);
                var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
                userDto.Role = role;
                usersDto.Add(userDto);
            }
            return !usersDto.Any()
                ? new Tuple<IEnumerable<UserDto>, IdentityResult>(usersDto, IdentityResult.Failed())
                : new Tuple<IEnumerable<UserDto>, IdentityResult>(usersDto, IdentityResult.Success);
        }

        public async Task<Tuple<UserDto, IdentityResult>> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return new Tuple<UserDto, IdentityResult>(default, IdentityResult.Failed());
            }
            var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            var userDto = _mapper.Map<UserDto>(user);
            userDto.Role = role;
            return new Tuple<UserDto, IdentityResult>(userDto, IdentityResult.Success);
        }

        public async Task<Tuple<UserDto, IdentityResult>> CreateUserAsync(CreateUserDto modelDto)
        {
            var user = _mapper.Map<User>(modelDto);
            var result = await _userManager.CreateAsync(user, modelDto.Password);
            if (!result.Succeeded)
            {
                return new Tuple<UserDto, IdentityResult>(default, IdentityResult.Failed());
            }

            await _userManager.AddToRoleAsync(user, modelDto.Role);
            modelDto.Id = user.Id;

            var massage = _notificationService.CreateMessageAboutUserCreation(user, modelDto.Password);
            await _notificationService.SendEmailAsync(massage,
                "Access to the Bookstore", user.Email);

            return new Tuple<UserDto, IdentityResult>(modelDto, IdentityResult.Success);
        }

        public async Task<Tuple<UserDto, IdentityResult>> CreateUserWithRandomPassAsync(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var password = CreateRandomPassword();
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                return new Tuple<UserDto, IdentityResult>(default, IdentityResult.Failed());
            }

            await _userManager.AddToRoleAsync(user, userDto.Role);
            userDto.Id = user.Id;

            var massage = _notificationService.CreateMessageAboutUserCreation(user, password);
            await _notificationService.SendEmailAsync(massage,
                "Access to the Bookstore", user.Email);

            return new Tuple<UserDto, IdentityResult>(userDto, IdentityResult.Success);
        }

        private string CreateRandomPassword(int passwordLength = 10)
        {
            const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            var randNum = new Random();
            var chars = new char[passwordLength];
            var allowedCharCount = allowedChars.Length;

            for (var i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[(int)((allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }

        public async Task<IdentityResult> EditUserAsync(UserDto userDto)
        {

            var user = await _userManager.FindByIdAsync(userDto.Id);
            if (user == null)
            {
                return IdentityResult.Failed();
            }

            user = _mapper.Map<User>(userDto);
            var identityResult = await UpdateUserRoleAsync(user, userDto);
            if (!identityResult.Succeeded)
            {
                return IdentityResult.Failed();
            }

            var resultUpdate = await _userManager.UpdateAsync(user);
            return !resultUpdate.Succeeded 
                ? IdentityResult.Failed() 
                : IdentityResult.Success;
        }

        private async Task<IdentityResult> UpdateUserRoleAsync(User user, UserDto userDto)
        {
            var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            var resultRemove = _userManager.RemoveFromRoleAsync(user, role).Result;
            if (!resultRemove.Succeeded)
            {
                return IdentityResult.Failed();
            }
            var resultAddRole = _userManager.AddToRoleAsync(user, userDto.Role).Result;
            return !resultAddRole.Succeeded 
                ? IdentityResult.Failed() 
                : IdentityResult.Success;
        }
        public async Task<IdentityResult> DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return IdentityResult.Failed();
            }

            await _userManager.DeleteAsync(user);
            return IdentityResult.Success;
        }

        public async Task<Tuple<IEnumerable<string>, IdentityResult>> GetRolesAsync()
        {
            var namesRole = await _roleManager.Roles.Select(x => x.Name).ToListAsync();
            return !namesRole.Any()
                ? new Tuple<IEnumerable<string>, IdentityResult>(default, IdentityResult.Failed())
                : new Tuple<IEnumerable<string>, IdentityResult>(namesRole, IdentityResult.Success);
        }
    }
}
