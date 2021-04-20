using AutoMapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TopicDTO, Topic>().ReverseMap();
            CreateMap<Message, MessageDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
