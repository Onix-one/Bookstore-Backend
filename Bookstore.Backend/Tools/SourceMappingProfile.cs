using AutoMapper;
using Bookstore.Core.Models.Entities;
using Bookstore.Core.Models.ModelsDTO.AuthorModels;

namespace Bookstore.Backend.Tools
{
    public class SourceMappingProfile : Profile
    {
        //CreateMap<Teacher, ProfileViewModel>().ReverseMap();
        //CreateMap<Group, GroupViewModel>()
        //.ForMember(model => model.TeacherName,
        //map => map
        //    .MapFrom(g => $"{g.Teacher.LastName} {g.Teacher.FirstName}"))
        //.ReverseMap();
        public SourceMappingProfile()
        {
            CreateMap<int, TypeOfBook>().ForMember(dest => dest.Id, m => m.MapFrom(src => src));
            CreateMap<CreateNewAuthorModel, Author>() // TODO this is test variant
                .ForMember(nameof(Author.TypesOfBooks),
                    config => config.MapFrom(src => src.TypesOfBookId));



            //{
            //    cfg.CreateMap<string, Phone>().ForMember(dest => dest.PhoneNumber, m => m.MapFrom(src => src)); // <-- important line!
            //    cfg.CreateMap<DomainUser, EntityUser>()
            //        .ForMember(dest => dest.Name, m => m.MapFrom(src => src.Username))
            //        .ForMember(dest => dest.PhoneNumbers, m => m.MapFrom(src => src.PhoneNumbers));
            //});
            //ForMember(nameof(ShowLotsModel.UrlImages),
            //    config => config.MapFrom(x => x.UrlImages.Select(a => a.Url).ToList()));
            //CreateMap<Lot, ShowLotsModel>().
            //    ForMember(nameof(ShowLotsModel.BuyoutPrice),
            //        config => config.MapFrom(x => Math.Max(x.BuyoutPrice, x.StartPrice))).

        }
    }
}