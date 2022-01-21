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

namespace Bookstore.Backend.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthorService _authorService;
        private readonly IGenreOfBookRepository _genreOfBookRepository;

        public AuthorController(IMapper mapper,
            IAuthorService authorService,
            IGenreOfBookRepository genreOfBookRepository)
        {
            _mapper = mapper;
            _authorService = authorService;
            _genreOfBookRepository = genreOfBookRepository;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateNewAuthorModel author)
        {
            var genreOfBooks = new List<GenreOfBook>();

            foreach (var genreId in author.GenresOfBookId)
            {
                var genre = await _genreOfBookRepository.GetByIdAsync(genreId);
                genreOfBooks.Add(genre);
            }

            var newAuthor = _mapper.Map<Author>(author);

            newAuthor.GenreOfBooks = genreOfBooks;
            await _authorService.CreateNewAuthorAsync(newAuthor);
            return Ok();
        }

        [HttpPost] //TODO Change model 
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
        [HttpGet]
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
