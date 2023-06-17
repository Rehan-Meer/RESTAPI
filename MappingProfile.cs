using AutoMapper;

namespace BasicAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile() => CreateMap<BreakfastDto, Breakfast>().ReverseMap();
    }
}
