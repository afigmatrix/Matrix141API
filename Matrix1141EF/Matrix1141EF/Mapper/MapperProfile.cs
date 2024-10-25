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
            CreateMap<Library, LibraryCreateDto>().ReverseMap();
            CreateMap<Library, LibraryGetByIdDto>().ReverseMap();
            CreateMap<UserCreateDTO, User>().ReverseMap();
            CreateMap<RoleCreateDTO,Role>().ReverseMap();
            CreateMap<Role,RoleGetDTO>().ReverseMap();
            CreateMap<ProductCreateDTO,Product>().ReverseMap();
            CreateMap<Product,ProductGetDTO>().ReverseMap();
            CreateMap<CategoryCreateDTO,Category>().ReverseMap();
            CreateMap<Category,CategoryGetDTO>().ReverseMap();
        }
    }
}
