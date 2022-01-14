using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bookstore.Backend.Models;
using Bookstore.BLL.Interfaces;
using Bookstore.BLL.Models;

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
        public async Task CreateBook(Book book) // TODO What to return
        {
            var newBook = _mapper.Map<BookDTO>(book); 
            await _bookService.AddNewBook(newBook);

        }
        [HttpDelete]// TODO What to return
        public async Task DeleteBook(int bookId)
        {
           await _bookService.DeleteBook(bookId);
        }
        [HttpDelete]
        public async Task GetBook()
        {

        }
        [HttpGet]
        public async Task<List<Book>> GetBooksByAuthor(int AuthorId) // TODO What to return
        {
              await _bookService.GetBooksByAuthor(AuthorId);

              throw new Exception();
        }
    }
}
