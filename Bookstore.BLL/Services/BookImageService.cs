using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookstore.DAL.EF.Repositories;

namespace Bookstore.BLL.Services
{
    public class BookImageService: IBookImageService
    {
        private IBookImageRepository _bookImageRepository;

        public BookImageService(IBookImageRepository bookImageRepository)
        {
            _bookImageRepository = bookImageRepository;
        }

        public async Task DeleteImage(int imageId)
        {
            var bookImageDelete = await _bookImageRepository.GetById(imageId);

            if (bookImageDelete == null)
            {
                throw new ArgumentNullException(nameof(bookImageDelete), $"Book with id={imageId} doesn't exist");
            }

            await _bookImageRepository.Delete(bookImageDelete);
        }
    }

    public interface IBookImageService
    {
        public Task DeleteImage(int imageId);
    }
}
