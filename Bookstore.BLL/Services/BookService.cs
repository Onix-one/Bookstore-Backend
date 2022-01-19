using AutoMapper;
using Bookstore.BLL.Interfaces;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO;
using Bookstore.Core.Models.ModelsDTO.BookModels;
using Bookstore.Core.Models.ModelsDTO.FilterModels;
using Bookstore.DAL.ADO.Repositories.Interfaces;
using Bookstore.DAL.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepositoryAdo _bookRepositoryAdo;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookImageService _bookImageService;
        private readonly IBookImageRepository _bookImageRepository;
        private readonly IGenreOfBookRepository _genreOfBookRepository;
        public BookService(IBookRepositoryAdo bookRepositoryAdo,
            IMapper mapper,
            IAuthorRepository authorRepository,
            IBookRepository bookRepository,
            IBookImageRepository bookImageRepository,
            IBookImageService bookImageService, IGenreOfBookRepository genreOfBookRepository)
        {
            _bookRepositoryAdo = bookRepositoryAdo;
            _mapper = mapper;
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _bookImageRepository = bookImageRepository;
            _bookImageService = bookImageService;
            _genreOfBookRepository = genreOfBookRepository;
        }

        public async Task AddNewBookAsync(CreateNewBookModel book)
        {
            var images = await _bookImageService.ConvertIFormFileToListOfBookImagesAsync(book.ImageFiles);

            var genres = new List<GenreOfBook>();
            var authors = new List<Author>();

            foreach (var id in book.GenresOfBookId)
            {
                var genre = await _genreOfBookRepository.GetByIdAsync(id);
                genres.Add(genre);
            }

            foreach (var id in book.AuthorsId)
            {
                var author = await _authorRepository.GetByIdAsync(id);
                authors.Add(author);
            }


            var newBook = _mapper.Map<Book>(book);

            newBook.Authors = authors;
            newBook.GenreOfBooks = genres;
            newBook.Images = images;

            await _bookRepositoryAdo.SaveAsync(newBook);
        }

        public async Task DeleteBookAsync(int bookId)
        {
            var bookToDelete = await _bookRepositoryAdo.GetByIdAsync(bookId);

            if (bookToDelete == null)
            {
                throw new ArgumentNullException(nameof(bookToDelete), $"Book with id={bookId} doesn't exist");
            }

            await _bookRepositoryAdo.DeleteAsync(bookToDelete);
        }

        public async Task<BookDTO> GetBookByIdAsync(int bookId)
        {
            var book = await _bookRepository.GetByIdAsync(bookId); // TODO What a fuck with include

            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), $"Book with id={bookId} doesn't exist");
            }

            var result = _mapper.Map<BookDTO>(book); //TODO not work  

            return result;
        }

        public async Task<List<BooksForAuthorFiltr>> GetBooksByAuthorAsync(int authorId)
        {
            var author = await _authorRepository.GetByIdAsync(authorId); // Mayby this code Y

            if (author == null)
            {
                throw new ArgumentNullException(nameof(author), $"Author with id={authorId} doesn't exist");
            }

            return await _bookRepositoryAdo.GetBooksByAuthorAsync(author);
        }
        public async Task<List<BooksByGenreFiltr>> GetBooksByGenresAsync(List<int> genresId)
        {
            return await _bookRepositoryAdo.GetBooksByGenresAsync(genresId);
        }
    }
}
