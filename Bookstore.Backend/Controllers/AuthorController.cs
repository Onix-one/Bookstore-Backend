using AutoMapper;
using Bookstore.BLL.Services;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO;
using Bookstore.Core.Models.ModelsDTO.AuthorModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Bookstore.Backend.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "ManagerRights")]
    public class AuthorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthorService _authorService;

        public AuthorController(IMapper mapper, IAuthorService authorService)
        {
            _mapper = mapper;
            _authorService = authorService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateNewAuthorModel author)
        {
            var newAuthor = _mapper.Map<Author>(author);
            await _authorService.CreateNewAuthorAsync(newAuthor);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Edit([FromBody] AuthorDTO author)
        {
            var newAuthor = _mapper.Map<Author>(author);
            await _authorService.EditAuthorAsync(newAuthor);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int authorId)
        {
            await _authorService.DeleteAuthorAsync(authorId);

            return Ok();
        }

        /// <summary>
        /// Get all authors without books and genres
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<AuthorDTO>> GetAll() 
        {
            var result = await _authorService.GetAllAuthorsAsync();

            if (result.Any())
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
