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
        private IBookImageRepository _bookImageRepository;

        public BookImageService(IBookImageRepository bookImageRepository)
        {
            _bookImageRepository = bookImageRepository;
        }

        public async Task DeleteImageAsync(int imageId)
        {
            var bookImageDelete = await _bookImageRepository.GetByIdAsync(imageId);

            if (bookImageDelete == null)
            {
                throw new ArgumentNullException(nameof(bookImageDelete), $"Book with id={imageId} doesn't exist");
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
    }
}
