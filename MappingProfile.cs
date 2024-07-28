using AutoMapper;
using BasicAPI.DTOs;

namespace BasicAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskStatusEnumDto, TaskStatus>().ReverseMap();

            CreateMap<TaskDto, Task>().ReverseMap();

            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
