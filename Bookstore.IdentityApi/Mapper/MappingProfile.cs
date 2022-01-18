using AutoMapper;
using Bookstore.IdentityApi.Dto;
using Bookstore.IdentityApi.Models;

namespace Bookstore.IdentityApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
