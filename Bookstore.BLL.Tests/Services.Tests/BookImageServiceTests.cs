using Bookstore.BLL.Services;
using Bookstore.Core.Models.Entities;
using Bookstore.DAL.EF.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.BLL.Tests.Services.Tests
{
    public class BookImageServiceTests
    {

        Mock<IUnitOfWork> _unitOfWork;
        Mock<IFileService> _fileService;
        BookImageService _bookImageService;

        [SetUp]
        public void Setup()
        {
            _fileService = new Mock<IFileService>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Test]
        [TestCase(1, "rootPath")]
        public async Task AddNewImageToExistBookAsync_(int bookId, string rootPath)
        {
            // Arrange
            var listIformFiles = new List<IFormFile>();
            var book = new Book() { Id = 1, Name = "best" };
            _bookImageService = new BookImageService(_fileService.Object, _unitOfWork.Object);
            _unitOfWork.Setup(x => x.BookRepository.GetByIdAsync(bookId)).ReturnsAsync((Book)null);

            _unitOfWork.Setup(x => x.BookImageRepository.SaveAsync(_bookImageService.NewImage));
            _fileService.Setup(x => x.GetFullPathToImage(book.Name, book.Id, _bookImageService.NewImage.Id)).Returns("imageURL");


            // Act


            _bookImageService.AddNewImageToExistBookAsync(listIformFiles, bookId, rootPath);
            //Assert
            _unitOfWork.Verify(x => x.BookImageRepository.SaveAsync(_bookImageService.NewImage));
            _fileService.Verify(x => x.GetFullPathToImage(book.Name, book.Id, _bookImageService.NewImage.Id));
        }
    }
}


//var book = await _unitOfWork.BookRepository.GetByIdAsync(bookId);

//            if (book == null)
//            {
//                throw new ArgumentNullException(nameof(book), $"Book with id={bookId} doesn't exist");
//}

//_fileService.CreateNewFolderForBook(rootPath, book.Id);

//foreach (var item in images)
//{
//    var newImage = new BookImage() { Book = book };

//    await _unitOfWork.BookImageRepository.SaveAsync(newImage);

//    var imageUrl = _fileService.GetFullPathToImage(book.Name, book.Id, newImage.Id);

//    var fullPath = Path.Combine(rootPath, imageUrl);

//    await _fileService.SaveFileInFolderAsync(item, fullPath);

//    newImage.ImageUrl = imageUrl;

//    await _unitOfWork.BookImageRepository.SaveAsync(newImage);
//}
//await _unitOfWork.SaveAsync();
//}

