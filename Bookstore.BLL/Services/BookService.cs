using AutoMapper;
using Bookstore.BLL.Interfaces;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO;
using Bookstore.Core.Models.ModelsDTO.BookModels;
using Bookstore.DAL.ADO.Repositories.Interfaces;
using Bookstore.DAL.EF.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Core.Models.ModelsDTO.FilterModels;
using Bookstore.DAL.EF.Repositories.Interfaces;
using Bookstore.DAL.EF.Repositories.Repositories;

namespace Bookstore.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepositoryAdo _bookRepositoryAdo;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IBookImageService _bookImageService;
        private readonly IUnitOfWork _unitOfWork;
        public BookService(IBookRepositoryAdo bookRepositoryAdo,
            IMapper mapper,
            IBookImageRepository bookImageRepository,
            IBookImageService bookImageService,
            IGenreOfBookRepository genreOfBookRepository,
            IFileService fileService, IUnitOfWork unitOfWork)
        {
            _bookRepositoryAdo = bookRepositoryAdo;
            _mapper = mapper;
            _bookImageService = bookImageService;
            _fileService = fileService;
            _unitOfWork = unitOfWork;
        }

        public async Task AddNewBookAsync(CreateNewBookModel book, string rootPath)
        {
            var genres = await _unitOfWork.GenreOfBookRepository.GetByListOfIdAsync(book.GenresOfBookId);

            var authors = await _unitOfWork.AuthorRepository.GetByListOfIdAsync(book.AuthorsId);

            var images = new List<BookImage>();

            var newBook = _mapper.Map<Book>(book);

            newBook.Authors = authors;
            newBook.GenreOfBooks = genres;

            await _unitOfWork.BookRepository.SaveAsync(newBook);
            await _unitOfWork.SaveAsync();

            _fileService.CreateNewFolderForBook(rootPath, newBook.Id);

            //create new BookImage. SaveAsync in database. SaveAsync image in folder. SaveAsync imageUrl in database.
            foreach (var image in book.ImageFiles)
            {
                var newImage = new BookImage { Book = newBook };

                await _bookImageService.CreateBookImageAsync(newImage);

                var imageUrl = _fileService.GetFullPathToImage(newBook.Name, newBook.Id, newImage.Id);

                var fullPathForImage = Path.Combine(rootPath, imageUrl);

                await _fileService.SaveFileInFolderAsync(image, fullPathForImage);

                newImage.ImageUrl = imageUrl;

                await _unitOfWork.BookImageRepository.SaveAsync(newImage);

                images.Add(newImage);
            }

            var bookUrl = _fileService.GetFullPathToBook(newBook.Name, newBook.Id);

            var fullPathForBook = Path.Combine(rootPath, bookUrl);

            await _fileService.SaveFileInFolderAsync(book.book, fullPathForBook);

            newBook.BookUrl = bookUrl;
            newBook.Images = images;

            await _unitOfWork.BookRepository.SaveAsync(newBook);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteBookAsync(int bookId)
        {
            var bookToDelete = await _bookRepositoryAdo.GetByIdAsync(bookId);

            if (bookToDelete == null)
            {
                throw new ArgumentNullException(nameof(bookToDelete), $"Book with id={bookId} doesn't exist");
            }

            await _bookRepositoryAdo.DeleteAsync(bookToDelete);
            await _unitOfWork.SaveAsync();
        }

        public async Task<BookDTO> GetBookByIdAsync(int bookId)
        {
            var book = await _unitOfWork.BookRepository.GetByIdAsync(bookId); // TODO What a fuck with include

            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), $"Book with id={bookId} doesn't exist");
            }

            var result = _mapper.Map<BookDTO>(book);

            return result;
        }

        public async Task<GetMaxAndMinPriceInfo> GetMinAndMaxPriceAsync()
        {
            return await _unitOfWork.BookRepository.GetMaxAndMinPriceAsync();
        }

        public async Task<LoadBookModel> LoadBookAsync(int bookId)
        {
            var book = await _bookRepositoryAdo.GetBookUrlAndNameAsync(bookId);
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), $"Book with id={bookId} doesn't exist");
            }

            return _mapper.Map<LoadBookModel>(book);
        }
        //TODO This method mybe we will not use
        public async Task<List<BooksByGenreFiltr>> GetBooksByGenresAsync(List<int> genresId)
        {
            return await _bookRepositoryAdo.GetBooksByGenresAsync(genresId);
        }

        //TODO This method not work and maybe we will not use it
        public async Task<List<BooksForAuthorFilter>> GetBooksByAuthorAsync(int authorId)
        {
            var author = await _unitOfWork.AuthorRepository.GetByIdAsync(authorId);

            if (author == null)
            {
                throw new ArgumentNullException(nameof(author), $"Author with id={authorId} doesn't exist");
            }

            return await _bookRepositoryAdo.GetBooksByAuthorAsync(author);
        }

        public async Task<List<BooksAfterFilterModel>> GetBooksByFilterAsync(FilterForBookModel conditions)
        {
            var books = await _unitOfWork.BookRepository.GetBooksByFilterAsync(conditions);

            return _mapper.Map<List<BooksAfterFilterModel>>(books);
        }
    }
}
