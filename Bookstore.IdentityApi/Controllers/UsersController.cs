using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bookstore.IdentityApi.Dto;
using Bookstore.IdentityApi.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.IdentityApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy  = "ManagerRights")]
    public class UsersController : Controller
    {

        private readonly IUserService _userService;
        
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var (usersDto, identityResult) = await _userService.GetAllUsersAsync();
            if (!identityResult.Succeeded)
            {
                return NotFound();
            }
            return Ok(usersDto);
        }
        
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetUserById(string id)
        {
            var (userDto, identityResult) = await _userService.GetUserByIdAsync(id);

            if (identityResult == null)
            {
                return NotFound();
            }

            return Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(CreateUserDto modelDto)
        {
            var (userDto, identityResult) = await _userService.CreateUserAsync(modelDto);
            if (!identityResult.Succeeded)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetAllUsers), new { id = userDto.Id }, modelDto);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUserWithRandomPass(UserDto modelDto)
        {
            var (userDto, identityResult) = await _userService.CreateUserWithRandomPassAsync(modelDto);
            if (!identityResult.Succeeded)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetAllUsers), new { id = userDto.Id }, modelDto);
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> EditUser(UserDto modelDto)
        {
            var identityResult = await _userService.EditUserAsync(modelDto);
            if (!identityResult.Succeeded)
            {
                return BadRequest();
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var identityResult = await _userService.DeleteUserAsync(id);
            if (!identityResult.Succeeded)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("roles")]
        public async Task<ActionResult<IEnumerable<string>>> GetRoles()
        {
            var (namesRole, identityResult) = await _userService.GetRolesAsync();
            if (!identityResult.Succeeded)
            {
                return NotFound();
            }
            return Ok(namesRole);
        }
    }
}
