using AutoMapper;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO;
using Bookstore.DAL.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task CreateNewAuthorAsync(Author author)
        {
            await _authorRepository.SaveAsync(author);
        }
        public async Task DeleteAuthorAsync(int authorId)
        {
            var authorToDelete = await _authorRepository.GetByIdAsync(authorId);

            if (authorToDelete == null)
            {
                throw new ArgumentNullException(nameof(authorToDelete), $"Author with id={authorId} doesn't exist");
            }

            await _authorRepository.DeleteAsync(authorToDelete);
        }
        public async Task EditAuthorAsync(Author author)
        {
            await _authorRepository.SaveAsync(author);
        }

        public async Task<AuthorDTO> GetAuthorByIdAsync(int authorId)
        {
           var author =  await _authorRepository.GetByIdAsync(authorId);

           return _mapper.Map<AuthorDTO>(author);
        }

        public async Task<List<AuthorDTO>> GetAllAuthorsAsync()
        {
            var authors = await _authorRepository.GetAllAsync(); // TODO what about books and type. Maybe override

            var authorsDto = _mapper.Map<List<AuthorDTO>>(authors);

            return authorsDto;
        }
        public async Task<List<AuthorDTO>> GetAllAuthorsWithBooksAsync()
        {
            var authors = await _authorRepository.GetAllAsync(); // TODO what about books and type. Maybe override

            var authorsDto = _mapper.Map<List<AuthorDTO>>(authors);

            return authorsDto;
        }
    }

    public interface IAuthorService
    {
        public Task CreateNewAuthorAsync(Author author);
        public Task DeleteAuthorAsync(int authorId);
        public Task EditAuthorAsync(Author author);
        public Task<List<AuthorDTO>> GetAllAuthorsAsync();
        public Task<AuthorDTO> GetAuthorByIdAsync(int authorId);
    }
}
