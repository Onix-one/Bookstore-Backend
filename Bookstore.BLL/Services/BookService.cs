using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bookstore.BLL.Interfaces;
using Bookstore.BLL.Models;
using Bookstore.Core.Entities;
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

        public async Task AddNewBook(BookDTO book)
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

        public async Task<List<Book>> GetBooksByAuthor(int authorId)
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
