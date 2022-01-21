using AutoMapper;
using Bookstore.BLL.Interfaces;
using Bookstore.Core.Models.ModelsDTO;
using Bookstore.Core.Models.ModelsDTO.BookModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Backend.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    //TODO add roles
    public class BookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;
        private IWebHostEnvironment _webHostEnvironment { get; set; }

        public BookController(IMapper mapper,
            IBookService bookService,
            IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _bookService = bookService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<ActionResult> CreateBook([FromBody] CreateNewBookModel book) // TODO How to check result
        {
            var rootPath = _webHostEnvironment.WebRootPath;
            await _bookService.AddNewBookAsync(book, rootPath);
            return Ok();

        }
        [HttpDelete]
        public async Task<ActionResult> DeleteBook(int bookId)
        {
            await _bookService.DeleteBookAsync(bookId);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<BookDTO>> GetBookById(int bookId)
        {
            var result = await _bookService.GetBookByIdAsync(bookId);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        /// <summary>
        /// Get  without books and genres
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //public async Task<ActionResult<AuthorDTO>> GetAll(int skip, int take)
        //{
        //    var result = await _bookService.();

        //    if (result.Any())
        //    {
        //        return Ok(result);
        //    }

        //    return BadRequest(result);
        //}

        [HttpGet]
        [SwaggerResponse(200, Type = typeof(List<BooksForAuthorFiltr>))]
        public async Task<ActionResult> GetBooksByAuthor(int authorId) // TODO What to return
        {
            var result = await _bookService.GetBooksByAuthorAsync(authorId);

            if (!result.Any())
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpGet]
        [SwaggerResponse(200, Type = typeof(List<BooksByGenreFiltr>))]
        public async Task<ActionResult> GetBooksByGenre([FromBody] List<int> genresId)
        {
            var result = await _bookService.GetBooksByGenresAsync(genresId);

            if (!result.Any())
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
