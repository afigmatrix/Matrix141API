using AutoMapper;
using Matrix1141EF.Data.Entity;
using Matrix1141EF.Model.DTO;

namespace Matrix1141EF.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserCreateDTO, User>().ReverseMap();
            CreateMap<RoleCreateDTO,Role>().ReverseMap();
        }
    }
}
