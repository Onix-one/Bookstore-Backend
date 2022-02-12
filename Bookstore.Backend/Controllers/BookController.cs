using AutoMapper;
using Bookstore.BLL.Interfaces;
using Bookstore.Core.Models.ModelsDTO;
using Bookstore.Core.Models.ModelsDTO.BookModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Core.Models.ModelsDTO.FilterModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Bookstore.Backend.Controllers
{
    [Route("api/[controller]")]
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

        //[HttpPut]
        //public async Task<ActionResult> UpdateBook([FromBody] UpdateBookModel book) // TODO How to check result
        //{
        //    var rootPath = _webHostEnvironment.WebRootPath;
        //    await _bookService.AddNewBookAsync(book, rootPath);
        //    return Ok();
        //}

        [HttpDelete("{bookId}")]
        public async Task<ActionResult> DeleteBook(int bookId)
        {
            await _bookService.DeleteBookAsync(bookId);

            return Ok();
        }

        [HttpGet("{bookId}")]
        public async Task<ActionResult<BookDTO>> GetBookById(int bookId)
        {
            var result = await _bookService.GetBookByIdAsync(bookId);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("{bookId}/download")]
        public async Task<VirtualFileResult> DownloadBook(int bookId)
        {
            var book = await _bookService.LoadBookAsync(bookId);

            return File(book.BookUrl, "application/octet-stream", $"{book.Name}.pdf");
        }


        [HttpPost("minmax-price")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<GetMaxAndMinPriceInfo>> GetMaxAndMinPrice()
        {
            var result = await _bookService.GetMinAndMaxPriceAsync();

            return result != null ? (ActionResult)Ok(result) : BadRequest();
        }

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

        //TODO maybe this method we will not use
        [HttpPost("filterByAuthor/{authorId}")]
        [SwaggerResponse(200, Type = typeof(List<BooksForAuthorFilter>))]
        public async Task<ActionResult> GetBooksByAuthor(int authorId) // TODO What to return
        {
            var result = await _bookService.GetBooksByAuthorAsync(authorId);

            if (!result.Any())
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPost("filterByGenres")]
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

        [HttpPost("filter")]
        public async Task<ActionResult<List<BooksAfterFilterModel>>> GetBooksByFilter([FromBody] FilterForBookModel conditions)
        {
            var result = await _bookService.GetBooksByFilterAsync(conditions);

            return Ok(result);
        }
    }
}
