using System.Collections.Generic;
using AutoMapper;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO;
using Bookstore.Core.Models.ModelsDTO.AuthorModels;
using Bookstore.Core.Models.ModelsDTO.BookModels;
using Bookstore.Core.Models.ModelsDTO.GenreOfBookModel;

namespace Bookstore.Backend.Tools
{
    public class SourceMappingProfile : Profile
    {
        public SourceMappingProfile()
        {
            CreateMap<int, GenreOfBook>().ForMember(dest => dest.Id, m => m.MapFrom(src => src));
            CreateMap<CreateNewAuthorModel, Author>() // TODO this is test variant
                .ForMember(nameof(Author.GenreOfBooks),
                    config => config.MapFrom(src => src.GenresOfBookId));

            CreateMap<Author, AuthorDTO>().ReverseMap().ForMember(nameof(Author.GenreOfBooks),x=>x.Ignore()).ForMember(nameof(Author.Books), x => x.Ignore());
            CreateMap<GenreOfBook, GenreOfBookDTO>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<CreateNewBookModel, Book>().ReverseMap();
            CreateMap<CreateNewGenreOfBookModel, GenreOfBook>().ReverseMap();
            CreateMap<GetAllGenreModel, GenreOfBook>().ReverseMap();
            CreateMap<LoadBookModel, Book>().ReverseMap();
            CreateMap<Author, AuthorNamesAndIdInfo>()
                .ForMember(nameof(AuthorNamesAndIdInfo.FullName),
                    config => config.MapFrom(src => $"{src.FirstName} {src.SecondName}"));
            CreateMap<Book, BooksAfterFilterModel>();

        }
    }
}