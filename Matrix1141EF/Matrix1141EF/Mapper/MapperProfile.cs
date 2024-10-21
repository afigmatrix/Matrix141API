using AutoMapper;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;

namespace Matrix1141EF.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserGetDTO>().ReverseMap();
            CreateMap<User, UserCreateDTO>().ReverseMap().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
        }
    }
}
