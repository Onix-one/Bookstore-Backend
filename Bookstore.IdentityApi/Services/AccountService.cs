using System;
using System.Threading.Tasks;
using Bookstore.IdentityApi.Dto;
using Bookstore.IdentityApi.Interfaces;
using Bookstore.IdentityApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Bookstore.IdentityApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IMapper _mapper;

        public AccountService(SignInManager<User> signInManager,
            UserManager<User> userManager, IJwtTokenService jwtTokenService, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
            _mapper = mapper;
        }

        public async Task<Tuple<User, IdentityResult>> RegistrationAsync(RegistrationDto modelDto)
        {
            var user = new User
            {
                LastName = modelDto.LastName,
                FirstName = modelDto.FirstName,
                UserName = modelDto.Email,
                Email = modelDto.Email,
                DateOfBirth = modelDto.DateOfBirth,
                RegisteredAt = DateTime.Now,
            };
            var result = await _userManager.CreateAsync(user, modelDto.Password);
            if (!result.Succeeded)
            {
                return new Tuple<User, IdentityResult>(default, IdentityResult.Failed());

            }

            const string customerRole = "customer";
            await _userManager.AddToRoleAsync(user, customerRole);
            return new Tuple<User, IdentityResult>(user, IdentityResult.Success);
        }

        public async Task<bool> CheckUserExistsAsync(RegistrationDto modelDto)
        {
            return await _userManager.Users.AnyAsync(x => x.Email == modelDto.Email);
        }

        public async Task<Tuple<string, IdentityResult>> LoginAsync(LoginDto modelDto)
        {
            var user = await _userManager.FindByNameAsync(modelDto.Email);
            if (user == null)
            {
                return new Tuple<string, IdentityResult>(default, IdentityResult.Failed());
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, modelDto.Password, false);
            if (!result.Succeeded)
            {
                return new Tuple<string, IdentityResult>(default, IdentityResult.Failed());
            }

            user.LastLogin = DateTime.Now;
            await _userManager.UpdateAsync(user);

            var claimsIdentity = GetIdentityClaims(user);
            var token = _jwtTokenService.GenerateJwtToken(claimsIdentity);
            return new Tuple<string, IdentityResult>(token, IdentityResult.Success);
        }

        private ClaimsIdentity GetIdentityClaims(User user)
        {
            var roles = _userManager.GetRolesAsync(user).Result;
            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.Id),
                //Uncomment if necessary
                //new (ClaimsIdentity.DefaultNameClaimType, user.Email),
                //new (ClaimsIdentity.DefaultNameClaimType, user.FirstName),
                //new (ClaimsIdentity.DefaultNameClaimType, user.LastName),
                new (ClaimsIdentity.DefaultRoleClaimType, String.Join(",", roles))
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));
            return new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme, ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordDto modelDto)
        {
            var user = await _userManager.FindByIdAsync(modelDto.Id);
            if (user == null)
            {
                return IdentityResult.Failed();
            }
            var resultValidate = await _userManager.PasswordValidators[0]
                .ValidateAsync(_userManager, user, modelDto.NewPassword);
            if (!resultValidate.Succeeded)
            {
                return IdentityResult.Failed();
            }
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, modelDto.NewPassword);
            var resultUpdate = await _userManager.UpdateAsync(user);

            return !resultUpdate.Succeeded 
                ? IdentityResult.Failed() 
                : IdentityResult.Success;
        }

        public async Task<UserDto> GetCurrentUserAsync(User user)
        {
            var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            var userDto = _mapper.Map<UserDto>(user);
            userDto.Role = role;
            return userDto;
        }
    }
}
