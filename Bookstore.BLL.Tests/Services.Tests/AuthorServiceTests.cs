using AutoMapper;
using Bookstore.BLL.Services;
using Bookstore.Core.Models.Entities;
using Bookstore.DAL.ADO.Repositories.Repositories;
using Bookstore.DAL.EF.Repositories.Interfaces;
using Bookstore.DAL.EF.Repositories.Repositories;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Bookstore.BLL.Tests.Services.Tests
{
    class AuthorServiceTests
    {

        Mock<IAuthorRepository> _authorRepository;
        Mock<IMapper> _mapper;
        Mock<IUnitOfWork> _unitOfWork;
        Mock<IAuthorRepositoryAdo> _authorRepositoryAdo;
        AuthorService _authorService;

        [SetUp]
        public void Setup()
        {
            _authorRepository = new Mock<IAuthorRepository>();
            _mapper = new Mock<IMapper>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _authorRepositoryAdo = new Mock<IAuthorRepositoryAdo>();
        }

        [Test]
        public async Task CreateNewAuthorAsync()
        {
            // Arrange
            var author = new Author();
            _authorService = new AuthorService(_authorRepository.Object, _mapper.Object, _authorRepositoryAdo.Object,_unitOfWork.Object);
            _unitOfWork.Setup(x => x.SaveAsync());
            _unitOfWork.Setup(x => x.AuthorRepository.SaveAsync(author));

            // Act
            await _authorService.CreateNewAuthorAsync(author);
            //Assert
            _unitOfWork.Verify(x=>x.AuthorRepository.SaveAsync(author));
            _unitOfWork.Verify(x => x.SaveAsync());
        }
    }
}
