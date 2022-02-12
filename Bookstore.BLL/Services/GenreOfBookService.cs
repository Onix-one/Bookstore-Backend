using AutoMapper;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO;
using Bookstore.Core.Models.ModelsDTO.GenreOfBookModel;
using Bookstore.DAL.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bookstore.Core.Models.ModelsDTO.AuthorModels;
using Bookstore.DAL.EF.Repositories.Interfaces;

namespace Bookstore.BLL.Services
{
    public class GenreOfBookService : IGenreOfBookService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GenreOfBookService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateNewGenreOfBookAsync(GenreOfBook author)
        {
            await _unitOfWork.GenreOfBookRepository.SaveAsync(author);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteGenreOfBookAsync(int genreId)
        {
            var genreToDelete = await _unitOfWork.GenreOfBookRepository.GetByIdAsync(genreId);

            if (genreToDelete == null)
            {
                throw new ArgumentNullException(nameof(genreToDelete), $"GenreOfBook with id={genreId} doesn't exist");
            }

            await _unitOfWork.GenreOfBookRepository.DeleteAsync(genreToDelete);
            await _unitOfWork.SaveAsync();
        }

        public async Task EditGenreOfBookAsync(GenreOfBook genre)
        {
            await _unitOfWork.GenreOfBookRepository.SaveAsync(genre);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<GetAllGenreModel>> GetAllGenresOfBookAsync()
        {
            var genresOfBooks = await _unitOfWork.GenreOfBookRepository.GetAllAsync();

            var authorsDto = _mapper.Map<List<GetAllGenreModel>>(genresOfBooks);

            return authorsDto;
        }

        public async Task<GenreOfBookDTO> GetGenreOfBookByIdAsync(int genreId)
        {
            var genre = await _unitOfWork.GenreOfBookRepository.GetByIdAsync(genreId);

            return _mapper.Map<GenreOfBookDTO>(genre);
        }
        public async Task<List<GenreOfBookNamesAndIdInfo>> GetAllGenresByPartOfNameAsync(string partOfName)
        {
            var genres = await _unitOfWork.GenreOfBookRepository.GetAllGenresByPartOfNameAsync(partOfName.ToString().ToUpper());

            return _mapper.Map<List<GenreOfBookNamesAndIdInfo>>(genres);
        }
    }

    public interface IGenreOfBookService
    {
        public Task CreateNewGenreOfBookAsync(GenreOfBook author);
        public Task DeleteGenreOfBookAsync(int genreId);
        public Task EditGenreOfBookAsync(GenreOfBook genre);
        public Task<List<GetAllGenreModel>> GetAllGenresOfBookAsync();
        public Task<GenreOfBookDTO> GetGenreOfBookByIdAsync(int genreId);
        public Task<List<GenreOfBookNamesAndIdInfo>> GetAllGenresByPartOfNameAsync(string partOFName);
    }
}
