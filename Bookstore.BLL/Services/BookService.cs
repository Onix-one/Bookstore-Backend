using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bookstore.BLL.Interfaces;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO;
using Bookstore.Core.Models.ModelsDTO.FilterModels;
using Bookstore.DAL.ADO.Repositories;
using Bookstore.DAL.ADO.Repositories.Interfaces;
using Bookstore.DAL.EF.Repositories;

namespace Bookstore.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        public BookService(IBookRepository bookRepository, IMapper mapper, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _authorRepository = authorRepository;
        }

        public async Task AddNewBook(Book book)
        {
            var newBook = _mapper.Map<Book>(book);
            await _bookRepository.Save(newBook);
        }

        public async Task DeleteBook(int bookId)
        {
            var bookToDelete = await _bookRepository.GetById(bookId);

            if (bookToDelete == null)
            {
                throw new ArgumentNullException(nameof(bookToDelete), $"Book with id={bookId} doesn't exist");
            }

            await _bookRepository.Delete(bookToDelete);
        }

        public async Task<BookDTO> GetBookById(int bookId) //TODO how to take all needed data
        {
            var book = await _bookRepository.GetById(bookId);

            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), $"Book with id={bookId} doesn't exist");
            }

            var result = _mapper.Map<BookDTO>(book); //TODO not work  

            return result;
        }

        public async Task<List<BooksForAuthorFilter>> GetBooksByAuthor(int authorId)
        {
            var author = await _authorRepository.GetById(authorId);

            if (author == null)
            {
                throw new ArgumentNullException(nameof(author), $"Author with id={authorId} doesn't exist");
            }

            return await _bookRepository.GetBooksByAuthor(author);
        }
    }
}
