using System;
using System.Threading.Tasks;
using Bookstore.IdentityApi.Dto;
using Bookstore.IdentityApi.Interfaces;
using Bookstore.IdentityApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.IdentityApi.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {

        private readonly IAccountService _accountService;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;


        public AccountController(IAccountService accountService, 
            SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _accountService = accountService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Registration(RegistrationDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }
            if (await _accountService.CheckUserExistsAsync(model))
            {
                return BadRequest("Email already exists");
            }
            var (user, result) = await _accountService.RegistrationAsync(model);
            if (!result.Succeeded)
            {
                return BadRequest(model);
            }
            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResultModel>> Login(LoginDto modelDto)
        {
            var (token, identityResult,user,roles) = await _accountService.LoginAsync(modelDto);
            if (!identityResult.Succeeded)
            {
                return BadRequest();
            }

            return Ok(new LoginResultModel(new LoginUserInfoModel(user.UserName, user.Email), token, roles));
        }
        
        [HttpGet]
        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        [HttpPost]
        public async Task<ActionResult<string>> ChangePassword(ChangePasswordDto modelDto)
        {
            var identityResult = await _accountService.ChangePasswordAsync(modelDto);
            if (!identityResult.Succeeded)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = await _accountService.GetCurrentUserAsync(user);
            return Ok(userDto);
        }
    }
}
