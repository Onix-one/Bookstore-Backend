using AutoMapper;
using Bookstore.BLL.Interfaces;
using Bookstore.Core.Models.ModelsDTO;
using Bookstore.Core.Models.ModelsDTO.BookModels;
using Bookstore.Core.Models.ModelsDTO.FilterModels;
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

        public BookController(IMapper mapper, IBookService bookService)
        {
            _mapper = mapper;
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateBook([FromBody]CreateNewBookModel book) // TODO How to check result
        {
            await _bookService.AddNewBookAsync(book);
            return Ok();

        }
        [HttpDelete]
        public async Task<ActionResult> DeleteBook(int bookId)
        {
            await _bookService.DeleteBookAsync(bookId);

            return Ok();
        }

        [HttpGet] //TODO Not work / Get with mistake
        public async Task<ActionResult<BookDTO>> GetBookById(int bookId)
        {
            var result = await _bookService.GetBookByIdAsync(bookId);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

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
