using AutoMapper;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO;
using Bookstore.DAL.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bookstore.Core.Models.ModelsDTO.AuthorModels;
using Bookstore.DAL.ADO.Repositories;
using Bookstore.DAL.ADO.Repositories.Repositories;
using Bookstore.DAL.EF.Repositories.Interfaces;
using Bookstore.DAL.EF.Repositories.Repositories;

namespace Bookstore.BLL.Services
{
    public class AuthorService : IAuthorService
    {

        private readonly IMapper _mapper;
        private readonly IAuthorRepositoryAdo _authorRepositoryAdo;
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IAuthorRepository authorRepository,
            IMapper mapper,
            IAuthorRepositoryAdo authorRepositoryAdo,
            IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _authorRepositoryAdo = authorRepositoryAdo;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateNewAuthorAsync(Author author)
        {
            await _unitOfWork.AuthorRepository.SaveAsync(author);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAuthorAsync(int authorId)
        {
            var authorToDelete = await _unitOfWork.AuthorRepository.GetByIdAsync(authorId);

            if (authorToDelete == null)
            {
                throw new ArgumentNullException(nameof(authorToDelete), $"Author with id={authorId} doesn't exist");

            }

            await _unitOfWork.AuthorRepository.DeleteAsync(authorToDelete);
            await _unitOfWork.SaveAsync();
        }

        public async Task EditAuthorAsync(Author author)
        {
            await _unitOfWork.AuthorRepository.SaveAsync(author);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<AuthorNamesAndIdInfo>> GetAllAuthorsByPartOfNameAsync(string partOFName)
        {

            var authors = await _unitOfWork.AuthorRepository.GetAllAuthorsByPartOfNameAsync(partOFName.ToString().ToUpper());

            return _mapper.Map<List<AuthorNamesAndIdInfo>>(authors);
        }

        public async Task<AuthorDTO> GetAuthorByIdAsync(int authorId)
        {
            var author = await _unitOfWork.AuthorRepository.GetByIdAsync(authorId);

            return _mapper.Map<AuthorDTO>(author);
        }

        public async Task<List<AuthorDTO>> GetAllAuthorsAsync()
        {
            var authors = await _unitOfWork.AuthorRepository.GetAllAsync();

            var authorsDto = _mapper.Map<List<Author>, List<AuthorDTO>>(authors);

            return authorsDto;
        }

        public async Task<List<AuthorDTO>> GetAllAuthorsWithBooksAsync()
        {
            var authors = await _unitOfWork.AuthorRepository.GetAllAsync();

            var authorsDto = _mapper.Map<List<Author>, List<AuthorDTO>>(authors);

            return authorsDto;
        }

        public async Task<List<AuthorNamesAndIdInfo>> GetAllAuthorsNameAndId()
        {
            var authors = await _authorRepositoryAdo.GetAllAuthorsNameSurnameIdAsync();

            var authorsDto = _mapper.Map<List<AuthorNamesAndIdInfo>>(authors);

            return authorsDto;
        }
    }

    public interface IAuthorService
    {
        public Task CreateNewAuthorAsync(Author author);
        public Task DeleteAuthorAsync(int authorId);
        public Task EditAuthorAsync(Author author);
        public Task<List<AuthorDTO>> GetAllAuthorsAsync();
        public Task<List<AuthorNamesAndIdInfo>> GetAllAuthorsByPartOfNameAsync(string partOFName);
        public Task<AuthorDTO> GetAuthorByIdAsync(int authorId);
        public Task<List<AuthorNamesAndIdInfo>> GetAllAuthorsNameAndId();
    }
}
