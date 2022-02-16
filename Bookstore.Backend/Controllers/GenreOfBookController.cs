using System.Collections.Generic;
using AutoMapper;
using Bookstore.BLL.Services;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO;
using Bookstore.Core.Models.ModelsDTO.GenreOfBookModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Backend.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class GenreOfBookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenreOfBookService _genreOfBookService;

        public GenreOfBookController(IMapper mapper,
            IGenreOfBookService genreOfBookService)
        {
            _mapper = mapper;
            _genreOfBookService = genreOfBookService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateGenre([FromBody] CreateNewGenreOfBookModel genre)
        {
            var newGenre = _mapper.Map<GenreOfBook>(genre);

            await _genreOfBookService.CreateNewGenreOfBookAsync(newGenre);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> EditGenre([FromBody] GenreOfBookDTO genre)
        {
            var newGenre = _mapper.Map<GenreOfBook>(genre);
            await _genreOfBookService.EditGenreOfBookAsync(newGenre);

            return Ok();
        }

        [HttpDelete("{genreId}")]
        public async Task<ActionResult> DeleteGenre(int genreId)
        {
            await _genreOfBookService.DeleteGenreOfBookAsync(genreId);

            return Ok();
        }

        /// <summary>
        /// Get all Genre without books,authors and customers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<GetAllGenreModel>>> GetAllGenres()
        {
            var result = await _genreOfBookService.GetAllGenresOfBookAsync();

            if (result.Any())
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        /// <summary>
        /// Get genreOfBook by Id without books,authors and customers
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>
        [HttpGet("{genreId}")]
        public async Task<ActionResult<AuthorDTO>> GetGenreOfBookById(int genreId)
        {
            var result = await _genreOfBookService.GetGenreOfBookByIdAsync(genreId);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("{partOfName}")]
        public async Task<ActionResult<GenreOfBookNamesAndIdInfo>> GetAllGenresByPartOfName(string partOfName)
        {
            var result = await _genreOfBookService.GetAllGenresByPartOfNameAsync(partOfName);

            return Ok(result);
        }
    }
}
