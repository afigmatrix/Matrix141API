﻿using AutoMapper;
using Matrix1141EF.Data.Entity;
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
        }
    }
}
