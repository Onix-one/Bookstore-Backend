using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Bookstore.BLL.Interfaces;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO;
using Bookstore.Core.Models.ModelsDTO.BookModels;
using Bookstore.Core.Models.ModelsDTO.FilterModels;
using Swashbuckle.AspNetCore.Annotations;

namespace Bookstore.Backend.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    //TODO add roles
    public class BookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IBookService _bookService;

        public BookController(IMapper mapper, IBookService bookService)
        {
            _mapper = mapper;
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult> CreateBook(CreateNewBookModel book) // TODO How to check result
        {
            var newBook = _mapper.Map<Book>(book); // TODO HowtoMap
            await _bookService.AddNewBook(newBook);
            return Ok();

        }
        [HttpDelete]// TODO What to return
        public async Task DeleteBook(int bookId)
        {
            await _bookService.DeleteBook(bookId);
        }
        [HttpGet]
        public async Task GetBook(int bookId)
        {

        }

        [HttpGet]
        [SwaggerResponse(200,Type = typeof(List<BooksForAuthorFilter>))]
        public async Task<ActionResult> GetBooksByAuthor(int AuthorId) // TODO What to return
        {
            var result = await _bookService.GetBooksByAuthor(AuthorId);

            if (!result.Any())
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
