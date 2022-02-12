using Bookstore.Core.Models.Entities;
using Bookstore.DAL.EF.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.DAL.EF.Repositories.Interfaces;
using Bookstore.DAL.EF.Repositories.Repositories;

namespace Bookstore.BLL.Services
{
    public class BookImageService : IBookImageService
    {
        private readonly IFileService _fileService;
        private readonly IUnitOfWork _unitOfWork;

        public BookImageService(IFileService fileService,
            IUnitOfWork unitOfWork)
        {

            _fileService = fileService;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateBookImageAsync(BookImage bookImage)
        {
            await _unitOfWork.BookImageRepository.SaveAsync(bookImage);
            await _unitOfWork.SaveAsync();
        }

        public async Task AddNewImageToExistBookAsync(List<IFormFile> images, int bookId, string rootPath)
        {
            var book = await _unitOfWork.BookRepository.GetByIdAsync(bookId);

            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), $"Book with id={bookId} doesn't exist");
            }

            _fileService.CreateNewFolderForBook(rootPath, book.Id);

            foreach (var item in images)
            {
                var newImage = new BookImage() { Book = book };

                await _unitOfWork.BookImageRepository.SaveAsync(newImage);

                var imageUrl = _fileService.GetFullPathToImage(book.Name, book.Id, newImage.Id);

                var fullPath = Path.Combine(rootPath, imageUrl);

               await  _fileService.SaveFileInFolderAsync(item, fullPath);

                newImage.ImageUrl = imageUrl;

                await _unitOfWork.BookImageRepository.SaveAsync(newImage);
            }
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteImageAsync(int imageId)
        {
            var bookImageDelete = await _unitOfWork.BookImageRepository.GetByIdAsync(imageId);

            if (bookImageDelete == null)
            {
                throw new ArgumentNullException(nameof(bookImageDelete), $"Image with id={imageId} doesn't exist");
            }

            await _unitOfWork.BookImageRepository.DeleteAsync(bookImageDelete);
            await _unitOfWork.SaveAsync();
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
