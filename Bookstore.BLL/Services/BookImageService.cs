using Bookstore.Core.Models.Entities;
using Bookstore.DAL.EF.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.BLL.Services
{
    public class BookImageService : IBookImageService
    {
        private readonly IBookImageRepository _bookImageRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IFileService _fileService;

        public BookImageService(IBookImageRepository bookImageRepository, IBookRepository bookRepository, IFileService fileService)
        {
            _bookImageRepository = bookImageRepository;
            _bookRepository = bookRepository;
            _fileService = fileService;
        }

        public async Task CreateBookImageAsync(BookImage bookImage)
        {
            await _bookImageRepository.SaveAsync(bookImage);
        }

        public async Task AddNewImageToExistBookAsync(List<IFormFile> images, int bookId, string rootPath)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);

            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), $"Book with id={bookId} doesn't exist");
            }

            _fileService.CreateNewFolderForBook(rootPath, book.Id);

            foreach (var item in images)
            {
                var newImage = new BookImage() { Book = book };

                await _bookImageRepository.SaveAsync(newImage);

                var imageUrl = _fileService.GetFullPathToImage(book.Name, book.Id, newImage.Id);

                var fullPath = Path.Combine(rootPath, imageUrl);

               await  _fileService.SaveFileInFolderAsync(item, fullPath);

                newImage.ImageUrl = imageUrl;

                await _bookImageRepository.SaveAsync(newImage);
            }
        }

        public async Task DeleteImageAsync(int imageId)
        {
            var bookImageDelete = await _bookImageRepository.GetByIdAsync(imageId);

            if (bookImageDelete == null)
            {
                throw new ArgumentNullException(nameof(bookImageDelete), $"Image with id={imageId} doesn't exist");
            }

            await _bookImageRepository.DeleteAsync(bookImageDelete);
        }

        /// <summary>
        /// This Method is not used now. Will used for avatars images
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public async Task<List<BookImage>> ConvertIFormFileToListOfBookImagesAsync(List<IFormFile> files)
        {
            var images = new List<BookImage>();

            foreach (var image in files.Where(image => image.Length > 0))
            {
                await using (var ms = new MemoryStream())
                {
                    await image.CopyToAsync(ms);
                    var fileBytes = ms.ToArray();

                    images.Add(new BookImage { });
                }
            }

            return images;
        }
    }

    public interface IBookImageService
    {
        public Task DeleteImageAsync(int imageId);
        public Task<List<BookImage>> ConvertIFormFileToListOfBookImagesAsync(List<IFormFile> files);
        public Task CreateBookImageAsync(BookImage bookImage);
        public Task AddNewImageToExistBookAsync(List<IFormFile> images, int bookId,string rootPath);
    }
}
