using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO;
using Bookstore.DAL.EF.Repositories;

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

        public async Task CreateNewAuthor(Author author)
        {
            await _authorRepository.Save(author);
        }
        public async Task DeleteAuthor(int authorId)
        {
            var authorToDelete = await _authorRepository.GetById(authorId);

            if (authorToDelete == null)
            {
                throw new ArgumentNullException(nameof(authorToDelete), $"Author with id={authorId} doesn't exist");
            }

            await _authorRepository.Delete(authorToDelete);
        }
        public async Task EditAuthor(Author author)
        {
            await _authorRepository.Save(author);
        }

        public async Task<List<AuthorDTO>> GetAllAuthors()
        {
            var authors = await _authorRepository.GetAll(); // TODO what about books and type. Maybe override

            var authorsDto = _mapper.Map<List<AuthorDTO>>(authors);

            return authorsDto;
        }
    }

    public interface IAuthorService
    {
        public Task CreateNewAuthor(Author author);
        public Task DeleteAuthor(int authorId);
        public Task EditAuthor(Author author);
        public Task<List<AuthorDTO>> GetAllAuthors();
    }
}
