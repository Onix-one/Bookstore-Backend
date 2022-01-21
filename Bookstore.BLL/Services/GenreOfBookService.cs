using AutoMapper;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO;
using Bookstore.Core.Models.ModelsDTO.GenreOfBookModel;
using Bookstore.DAL.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookstore.BLL.Services
{
    public class GenreOfBookService : IGenreOfBookService
    {
        private readonly IGenreOfBookRepository _genreOfBookRepository;
        private readonly IMapper _mapper;

        public GenreOfBookService(IGenreOfBookRepository genreOfBookRepository,
            IMapper mapper)
        {
            _genreOfBookRepository = genreOfBookRepository;
            _mapper = mapper;
        }

        public async Task CreateNewGenreOfBookAsync(GenreOfBook author)
        {
            await _genreOfBookRepository.SaveAsync(author);
        }
        public async Task DeleteGenreOfBookAsync(int genreId)
        {
            var genreToDelete = await _genreOfBookRepository.GetByIdAsync(genreId);

            if (genreToDelete == null)
            {
                throw new ArgumentNullException(nameof(genreToDelete), $"GenreOfBook with id={genreId} doesn't exist");
            }

            await _genreOfBookRepository.DeleteAsync(genreToDelete);
        }
        public async Task EditGenreOfBookAsync(GenreOfBook genre)
        {
            await _genreOfBookRepository.SaveAsync(genre);
        }

        public async Task<List<GetAllGenreModel>> GetAllGenresOfBookAsync()
        {
            var genresOfBooks = await _genreOfBookRepository.GetAllAsync();

            var authorsDto = _mapper.Map<List<GetAllGenreModel>>(genresOfBooks);

            return authorsDto;
        }
        public async Task<GenreOfBookDTO> GetGenreOfBookByIdAsync(int genreId)
        {
            var genre = await _genreOfBookRepository.GetByIdAsync(genreId);

            return _mapper.Map<GenreOfBookDTO>(genre);
        }
    }

    public interface IGenreOfBookService
    {
        public Task CreateNewGenreOfBookAsync(GenreOfBook author);
        public Task DeleteGenreOfBookAsync(int genreId);
        public Task EditGenreOfBookAsync(GenreOfBook genre);
        public Task<List<GetAllGenreModel>> GetAllGenresOfBookAsync();
        public Task<GenreOfBookDTO> GetGenreOfBookByIdAsync(int genreId);
    }
}
