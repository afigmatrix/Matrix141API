using AutoMapper;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model;
using Matrix1141EF.Model.DTO;

namespace Matrix1141EF.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserGetDTO>().ReverseMap();
            CreateMap<Library,LibraryCreateDto>().ReverseMap();
            CreateMap<Library,LibraryGetByIdDto>().ReverseMap();
            CreateMap<User,UserGetDTO>().ReverseMap();
            CreateMap<UserCreateDTO,User>().ReverseMap();
            CreateMap<Student,StudentGetDTO>().ReverseMap();
            CreateMap<ProductCreateDTO,Product>().ReverseMap();
            CreateMap<User,UserUpdateDTO>().ReverseMap();
            CreateMap<Role,RoleUpdateDTO>().ReverseMap();
            CreateMap<Category,CategoryCreateDTO>().ReverseMap();
            CreateMap<Category,CategoryGetDTO>().ReverseMap();
            CreateMap<Product,ProductCreateDTO>().ReverseMap();
            CreateMap<Product,ProductUpdateDTO>().ReverseMap();
            CreateMap<ProductGetDTO, Product>().ReverseMap();
        }
    }
}
