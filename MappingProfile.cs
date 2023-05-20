using AutoMapper;
using BasicAPI.DTOs;
using BasicAPI.InternalModels;

namespace BasicAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BreakfastResponseDto, BreakfastModel>().ReverseMap();
        }
    }
}
