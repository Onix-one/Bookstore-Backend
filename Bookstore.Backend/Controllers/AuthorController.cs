using System.Collections.Generic;
using AutoMapper;
using Bookstore.BLL.Services;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO;
using Bookstore.Core.Models.ModelsDTO.AuthorModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.DAL.EF.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using NLog;
using LogLevel = NLog.LogLevel;


namespace Bookstore.Backend.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "ManagerRights")]
    public class AuthorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthorService _authorService;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(IMapper mapper,
            IAuthorService authorService,
            ILogger<AuthorController> logger)
        {
            _mapper = mapper;
            _authorService = authorService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAuthor([FromBody] CreateNewAuthorModel author)
        {
            var newAuthor = _mapper.Map<Author>(author);

            await _authorService.CreateNewAuthorAsync(newAuthor);
            return Ok();
        }

        [HttpPost] //TODO Change model 
        public async Task<ActionResult> EditAuthor([FromBody] AuthorDTO author)
        {
            var newAuthor = _mapper.Map<Author>(author);
            await _authorService.EditAuthorAsync(newAuthor);

            return Ok();
        }

        [HttpDelete("{authorId}")]
        public async Task<ActionResult> DeleteAuthor(int authorId)
        {
            await _authorService.DeleteAuthorAsync(authorId);

            return Ok();
        }

        /// <summary>
        /// Get all authors without books and genres
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<AuthorDTO>> GetAllAuthors()
        {
            var result = await _authorService.GetAllAuthorsAsync();

            if (result.Any())
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorNamesAndIdInfo>>> GetAllAuthorsByPartOfName(string partOFName)
        {
            var result = await _authorService.GetAllAuthorsByPartOfNameAsync(partOFName);

            return Ok(result);
            }

        [HttpGet]
        public async Task<ActionResult<List<AuthorNamesAndIdInfo>>> GetAllAuthorsNameAndId()
        {
            var result = await _authorService.GetAllAuthorsNameAndId();

            if (result.Any())
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("{authorId}")]
        public async Task<ActionResult<AuthorDTO>> GetAuthorByIdAsync(int authorId)
        {
            var result = await _authorService.GetAuthorByIdAsync(authorId);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
