using AutoMapper;
using Bookstore.Backend.Controllers;
using Bookstore.BLL.Services;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO.AuthorModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Bookstore.Backend.Tests.Controllers.Tests
{
    class AuthorControllerTests
    {
        Mock<IMapper> _mapper;
        Mock<IAuthorService> _authorService;
        Mock<ILogger<AuthorController>> _logger;
        AuthorController _authorController;

        [SetUp]
        public void Setup()
        {
            _mapper = new Mock<IMapper>();
            _authorService = new Mock<IAuthorService>();
            _logger = new Mock<ILogger<AuthorController>>();
           
        }

        [Test]
        public async Task CreateAuthor_ReturnOk()
        {
            // Arrange
            _authorController = new AuthorController(_mapper.Object, _authorService.Object, _logger.Object);
            var author = new Author();
            var model = new CreateNewAuthorModel();
            _mapper.Setup(x => x.Map<Author>(model)).Returns(author);
            _authorService.Setup(x => x.CreateNewAuthorAsync(author));

            // Act
            var result = await _authorController.CreateAuthor(model);
            // Assert
            _authorService.Verify(x => x.CreateNewAuthorAsync(author));
            Assert.IsInstanceOf<OkResult>(result);
        }

        //[HttpPost]
        //public async Task<ActionResult> CreateAuthor([FromBody] CreateNewAuthorModel author)
        //{
        //    var newAuthor = _mapper.Map<Author>(author);

        //    await _authorService.CreateNewAuthorAsync(newAuthor);
        //    return Ok();
        //}
    }
}

